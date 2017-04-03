if (typeof CMSEmergencySystem == 'undefined')
    CMSEmergencySystem = {};

// Namespace declaration
CMSEmergencySystem.Map = {};

// Class declaration
CMSEmergencySystem.Map.ContextMenu = null;

// Private variable declaration
CMSEmergencySystem.Map._MapOptions = {
    center: new google.maps.LatLng(1.354489, 103.858536),
    zoom: 10,
    zoomControl: true,
    zoomControlOptions: {
        style: google.maps.ZoomControlStyle.DEFAULT,
    },
    disableDoubleClickZoom: true,
    mapTypeControl: true,
    mapTypeControlOptions: {
        style: google.maps.MapTypeControlStyle.DROPDOWN_MENU,
    },
    scaleControl: true,
    scrollwheel: true,
    streetViewControl: true,
    draggable: true,
    overviewMapControl: true,
    overviewMapControlOptions: {
        opened: true,
    }
};
CMSEmergencySystem.Map._ContextMenuOptions = {
    menu: 'context_menu',
    menuSeperator: 'context_menu_separator',
    menuItems: [
        {
            className: 'context_menu_item',
            eventName: 'zoom_in_click',
            label: 'Zoom in'
        },
        {
            className: 'context_menu_item',
            eventName: 'zoom_out_click',
            label: 'Zoom out'
        },
        {
            className: 'context_menu_item',
            eventName: 'center_map_click',
            label: 'Center map here'
        }
    ]
};
CMSEmergencySystem.Map._IconMap = {
    "Fire Outbreak": "/Icons/Fire.png",
    "Dengue Outbreak": "/Icons/Dengue.png",
    "Earthquake": "/Icons/Earthquake.png"
};
CMSEmergencySystem.Map._Geocoder = new google.maps.Geocoder();
CMSEmergencySystem.Map._GeocoderResultMap = {};
CMSEmergencySystem.Map._Markers = [];
CMSEmergencySystem.Map._PlaceSelectedListener = [];
CMSEmergencySystem.Map._DefaultPlaceListener = [];

// Private uninitialized variable declaration
CMSEmergencySystem.Map._Map = null;
CMSEmergencySystem.Map._ContextMenu = null;
CMSEmergencySystem.Map._SearchBox = null;
CMSEmergencySystem.Map._AutoComplete = null;
CMSEmergencySystem.Map._InfoWindow = null;
CMSEmergencySystem.Map._InfoWindowContent = null;
CMSEmergencySystem.Map._DefaultPlace = null;
CMSEmergencySystem.Map._DefaultMarker = null;

// Function declaration

CMSEmergencySystem.Map.AddMarker = function (latlng, type, state, geocoderResult) {
    var markerOpts = {
        map: CMSEmergencySystem.Map._Map,
        position: latlng
    };

    if (type != "default")
        markerOpts["icon"] = CMSEmergencySystem.Map._IconMap[type];

    var marker = new google.maps.Marker(markerOpts);
    CMSEmergencySystem.Map._GeocoderResultMap[state] = geocoderResult;
    marker._State = state;

    marker.addListener('click', CMSEmergencySystem.Map.OnMarkerSelected);
    CMSEmergencySystem.Map._Markers.push(marker);

    return marker;
};

CMSEmergencySystem.Map.AddDefaultPlaceListener = function (listener) {
    CMSEmergencySystem.Map._DefaultPlaceListener.push(listener);
};

CMSEmergencySystem.Map.AddPlaceSelectedListener = function (listener) {
    CMSEmergencySystem.Map._PlaceSelectedListener.push(listener);
};

CMSEmergencySystem.Map.AdjustSearchRegionBias = function () {
    CMSEmergencySystem.Map._SearchBox.setBounds(CMSEmergencySystem.Map._Map.getBounds());
};

CMSEmergencySystem.Map.BuildContextMenuInstance = function () {
    // Create context menu object
    CMSEmergencySystem.Map._ContextMenu = new CMSEmergencySystem.Map.ContextMenu(CMSEmergencySystem.Map._Map, CMSEmergencySystem.Map._ContextMenuOptions);

    // Add event listener
    google.maps.event.addListener(CMSEmergencySystem.Map._Map, 'rightclick', CMSEmergencySystem.Map.ShowContextMenu);
    google.maps.event.addListener(CMSEmergencySystem.Map._ContextMenu, 'menu_item_selected', CMSEmergencySystem.Map.OnContextMenuItemSelected);
};

CMSEmergencySystem.Map.BuildContextMenuPrototype = function () {

    CMSEmergencySystem.Map.ContextMenu = function (map, options) {
        options = options || {};

        this.setMap(map);

        this.classNames_ = options.classNames || {};
        this.map_ = map;
        this.mapDiv_ = map.getDiv();
        this.menuItems_ = options.menuItems || [];
        this.pixelOffset = options.pixelOffset || new google.maps.Point(10, -5);
    }

    CMSEmergencySystem.Map.ContextMenu.prototype = new google.maps.OverlayView();

    CMSEmergencySystem.Map.ContextMenu.prototype.draw = function () {
        if (this.isVisible_) {
            var mapSize = new google.maps.Size(this.mapDiv_.offsetWidth, this.mapDiv_.offsetHeight);
            var menuSize = new google.maps.Size(this.menu_.offsetWidth, this.menu_.offsetHeight);
            var mousePosition = this.getProjection().fromLatLngToDivPixel(this.position_);

            var left = mousePosition.x;
            var top = mousePosition.y;

            if (mousePosition.x > mapSize.width - menuSize.width - this.pixelOffset.x) {
                left = left - menuSize.width - this.pixelOffset.x;
            } else {
                left += this.pixelOffset.x;
            }

            if (mousePosition.y > mapSize.height - menuSize.height - this.pixelOffset.y) {
                top = top - menuSize.height - this.pixelOffset.y;
            } else {
                top += this.pixelOffset.y;
            }

            this.menu_.style.left = left + 'px';
            this.menu_.style.top = top + 'px';
        }
    };

    CMSEmergencySystem.Map.ContextMenu.prototype.getVisible = function () {
        return this.isVisible_;
    };

    CMSEmergencySystem.Map.ContextMenu.prototype.hide = function () {
        if (this.isVisible_) {
            this.menu_.style.display = 'none';
            this.isVisible_ = false;
        }
    };

    CMSEmergencySystem.Map.ContextMenu.prototype.onAdd = function () {
        function createMenuItem(values) {
            var menuItem = document.createElement('div');
            menuItem.innerHTML = values.label;
            if (values.className) {
                menuItem.className = values.className;
            }
            if (values.id) {
                menuItem.id = values.id;
            }
            menuItem.style.cssText = 'cursor:pointer; white-space:nowrap';
            menuItem.onclick = function () {
                google.maps.event.trigger($this, 'menu_item_selected', $this.position_, values.eventName);
            };
            return menuItem;
        }
        function createMenuSeparator() {
            var menuSeparator = document.createElement('div');
            if ($this.classNames_.menuSeparator) {
                menuSeparator.className = $this.classNames_.menuSeparator;
            }
            return menuSeparator;
        }
        var $this = this;	//	used for closures

        var menu = document.createElement('div');
        if (this.classNames_.menu) {
            menu.className = this.classNames_.menu;
        }
        menu.style.cssText = 'display:none; position:absolute';

        for (var i = 0, j = this.menuItems_.length; i < j; i++) {
            if (this.menuItems_[i].label && this.menuItems_[i].eventName) {
                menu.appendChild(createMenuItem(this.menuItems_[i]));
            } else {
                menu.appendChild(createMenuSeparator());
            }
        }

        delete this.classNames_;
        delete this.menuItems_;

        this.isVisible_ = false;
        this.menu_ = menu;
        this.position_ = new google.maps.LatLng(0, 0);

        google.maps.event.addListener(this.map_, 'click', function (mouseEvent) {
            $this.hide();
        });

        this.getPanes().floatPane.appendChild(menu);
    };

    CMSEmergencySystem.Map.ContextMenu.prototype.onRemove = function () {
        this.menu_.parentNode.removeChild(this.menu_);
        delete this.mapDiv_;
        delete this.menu_;
        delete this.position_;
    };

    CMSEmergencySystem.Map.ContextMenu.prototype.show = function (latLng) {
        if (!this.isVisible_) {
            this.menu_.style.display = 'block';
            this.isVisible_ = true;
        }
        this.position_ = latLng;
        this.draw();
    };

};

CMSEmergencySystem.Map.BuildSearchBox = function (searchContainerID) {
    var input = document.getElementById(searchContainerID);

    // Create search box for wrapper for input element and append input to map control
    CMSEmergencySystem.Map._SearchBox = new google.maps.places.SearchBox(input);
    CMSEmergencySystem.Map._Map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

    // Create autocomplete wrapper for input element
    CMSEmergencySystem.Map._AutoComplete = new google.maps.places.Autocomplete(input, { placeIdOnly: true });
    CMSEmergencySystem.Map._AutoComplete.bindTo("bounds", CMSEmergencySystem.Map._Map);
    CMSEmergencySystem.Map._AutoComplete.setComponentRestrictions({ country: "SG" });

    // Set listener to listen for viewport changes on the map to adjust search box result region bias
    CMSEmergencySystem.Map._Map.addListener('bounds_changed', CMSEmergencySystem.Map.AdjustSearchRegionBias);
    // Set listener to listen for place result
    CMSEmergencySystem.Map._AutoComplete.addListener("place_changed", CMSEmergencySystem.Map.OnPlaceResult);
};

CMSEmergencySystem.Map.BuildInfoWindow = function (infoWindowID) {
    CMSEmergencySystem.Map._InfoWindow = new google.maps.InfoWindow();

    CMSEmergencySystem.Map._InfoWindowContent = document.getElementById(infoWindowID);
    CMSEmergencySystem.Map._InfoWindow.setContent(CMSEmergencySystem.Map._InfoWindowContent);
};

CMSEmergencySystem.Map.ClearMarker = function (marker) {
    if (marker == null) {
        // Remove marker
        marker.setMap(null);

        var index = CMSEmergencySystem.Map._Markers.indexOf(marker);
        if (index >= 0)
            CMSEmergencySystem.Map._Markers.splice(index, 1);
    }
    else {
        // Remove all marker if parameter is empty
        for (var i = 0; i < CMSEmergencySystem.Map._Markers.length; i++)
            CMSEmergencySystem.Map._Markers[i].setMap(null);
    }
};

CMSEmergencySystem.Map.Initialize = function (mapContainerID, searchContainerID, infoWindowID) {
    // Create google map object
    CMSEmergencySystem.Map._Map = new google.maps.Map(document.getElementById(mapContainerID), CMSEmergencySystem.Map._MapOptions);

    // Build class definition for CMSEmergencySystem.Map.ContextMenu
    CMSEmergencySystem.Map.BuildContextMenuPrototype();

    // Build context menu for map
    CMSEmergencySystem.Map.BuildContextMenuInstance();

    // Build search box for searching places
    CMSEmergencySystem.Map.BuildSearchBox(searchContainerID);

    // Build information window
    CMSEmergencySystem.Map.BuildInfoWindow(infoWindowID);
};

CMSEmergencySystem.Map.OnContextMenuItemSelected = function (latlng, event) {
    switch (event) {
        case 'zoom_in_click':
            CMSEmergencySystem.Map._Map.setZoom(CMSEmergencySystem.Map._Map.getZoom() + 1);
            break;
        case 'zoom_out_click':
            CMSEmergencySystem.Map._Map.setZoom(CMSEmergencySystem.Map._Map.getZoom() - 1);
            break;
        case 'center_map_click':
            CMSEmergencySystem.Map._Map.panTo(latlng);
            break;
    }
};

CMSEmergencySystem.Map.OnPlaceResult = function () {
    var place = CMSEmergencySystem.Map._AutoComplete.getPlace();

    CMSEmergencySystem.Map._InfoWindow.close();
    var geocodeOpts = null;
    if (!place.place_id)
        geocodeOpts = { address: place.name, componentRestrictions: { country: "SG" } };
    else
        geocodeOpts = { placeId: place.place_id };

    CMSEmergencySystem.Map._DefaultPlace = place;
    CMSEmergencySystem.Map._Geocoder.geocode(geocodeOpts, CMSEmergencySystem.Map.OnGeocodeResult);

    if (CMSEmergencySystem.Map._DefaultMarker != null)
        CMSEmergencySystem.Map._DefaultMarker.setMap(null);
};

CMSEmergencySystem.Map.OnGeocodeResult = function (results, status) {
    if (status == "OK") {
        var place = CMSEmergencySystem.Map._DefaultPlace;
        var gresult = results[0];

        gresult.latitude = gresult.geometry.location.lat();
        gresult.longitude = gresult.geometry.location.lng();
        gresult.name = place.name;

        var marker = CMSEmergencySystem.Map.AddMarker(results[0].geometry.location, "default", 0, gresult);
        CMSEmergencySystem.Map._Map.setCenter(results[0].geometry.location);

        CMSEmergencySystem.Map.ShowInfoWindow(marker);
        CMSEmergencySystem.Map._DefaultMarker = marker;

        for (var i = 0; i < CMSEmergencySystem.Map._DefaultPlaceListener.length; i++)
            CMSEmergencySystem.Map._DefaultPlaceListener[i](marker, CMSEmergencySystem.Map._GeocoderResultMap[marker._State]);
    }
    else {
        alert('Geocode was not successful for the following reason: ' + status);
    }
};

CMSEmergencySystem.Map.OnMarkerSelected = function () {
    CMSEmergencySystem.Map.ShowInfoWindow(this);

    for (var index = 0; index < CMSEmergencySystem.Map._PlaceSelectedListener.length; index++)
        CMSEmergencySystem.Map._PlaceSelectedListener[index](this, CMSEmergencySystem.Map._GeocoderResultMap[this._State]);
};

CMSEmergencySystem.Map.ReplaceMarker = function (marker, type) {
    var latlng = marker.getPosition();
    var place = marker._Place;

    CMSEmergencySystem.Map.ClearMarker(marker);

    return CMSEmergencySystem.Map.AddMarker(latlng, type, place);
};

CMSEmergencySystem.Map.ShowInfoWindow = function (marker) {
    var state = marker._State;
    var gresult = CMSEmergencySystem.Map._GeocoderResultMap[state];

    // Set information window content
    CMSEmergencySystem.Map._InfoWindowContent.children["place-name"].textContent = gresult.name;
    CMSEmergencySystem.Map._InfoWindowContent.children["place-address"].textContent = gresult.formatted_address ? gresult.formatted_address : "";
    CMSEmergencySystem.Map._InfoWindowContent.children["lat"].textContent = "Latitude: " + gresult.latitude;
    CMSEmergencySystem.Map._InfoWindowContent.children["lng"].textContent = "Longitude: " + gresult.longitude;
    //document.getElementById('LatInfo').value = gresult.latitude;
    //document.getElementById('LngInfo').value = gresult.longitude;

    CMSEmergencySystem.Map._InfoWindow.open(CMSEmergencySystem.Map._Map, marker);
};

CMSEmergencySystem.Map.ShowContextMenu = function (event) {
    CMSEmergencySystem.Map._ContextMenu.show(event.latLng);
};

CMSEmergencySystem.Map.RemoveDefaultPlaceListener = function (listener) {
    var index = CMSEmergencySystem.Map._DefaultPlaceListener.indexOf(listener);

    if (index >= 0)
        CMSEmergencySystem.Map._DefaultPlaceListener.splice(index, 1);
};

CMSEmergencySystem.Map.RemovePlaceSelectedListener = function (listener) {
    var index = CMSEmergencySystem.Map._PlaceSelectedListener.indexOf(listener);

    if (index >= 0)
        CMSEmergencySystem.Map._PlaceSelectedListener.splice(index, 1);
};