<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMSEmergencySystem.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


<script>
// Only works after `FB.init` is called
function myFacebookLogin() {
    FB.login(function () { }, { scope: 'publish_actions' });

}
function myFacebookPost() {

    FB.login(function () {
        // Note: The call will only work if you accept the permission request
        FB.api('/Crisis-Management-System-Xiao-Yao-Pai-406096709760870/posts', 'post', { message: 'Hello, world!' });
    }, { scope: 'publish_actions' });

}
</script>
<script>
        function w3_openleft() {
            document.getElementById("hiddenleftpanel").style.width = "auto";
            document.getElementById("mySidenav").style.width = "100%";
            document.getElementById("mySidenav").style.display = "block";
            document.getElementById("leftsidepanel").style.display = 'none';
            document.getElementById("hiddenleftpanel").style.display = 'block';
            document.getElementById("rightpanel").style.marginLeft = document.getElementById("hiddenleftpanel").offsetWidth + "px";
            document.getElementById("rightpanel").style.marginRight = "0px";

        }
        function w3_closeleft() {
            document.getElementById("mySidenav").style.display = "none";
            document.getElementById("hiddenleftpanel").style.display = "none";
            document.getElementById("leftsidepanel").style.display = "inline-block";
            document.getElementById("hiddenleftpanel").style.width = "0%";
            document.getElementById("rightpanel").style.marginLeft = document.getElementById("leftsidepanel").offsetWidth + "px";
        }

        function w3_openright() {
            document.getElementById("closerightpanel").style.width = "auto";
            document.getElementById("myRightSidenav").style.width = "100%";
            document.getElementById("myRightSidenav").style.display = "block";
            document.getElementById("openrightpanel").style.display = 'none';
            document.getElementById("closerightpanel").style.display = 'block';
            document.getElementById("rightpanel").style.marginRight = document.getElementById("closerightpanel").offsetWidth + "px";
        }
        function w3_closeright() {
            document.getElementById("myRightSidenav").style.display = "none";
            document.getElementById("closerightpanel").style.display = "none";
            document.getElementById("openrightpanel").style.display = "inline-block";
            document.getElementById("closerightpanel").style.width = "0%";
            document.getElementById("rightpanel").style.marginRight = document.getElementById("rightopenpanel").offsetWidth + "px";
        }

        function tab1() {
            document.getElementById("tabs-2").style.display = "none";
            document.getElementById("tabs-1").style.display = "inline-block";
        }
        function tab2() {
            document.getElementById("tabs-1").style.display = "none";
            document.getElementById("tabs-2").style.display = "inline-block";
        }
</script>

<script>
    function initialize() {
        // Get the modal
        // how sia
        //gg
        var modal = document.getElementById('myModal');
        var createModal = document.getElementById('CreateIncidentDialogBox');

        // Get the button that opens the modal
        var btn = document.getElementById("ViewDetails");

        var btn1 = document.getElementById("CreateIncident");

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];
        var span1 = document.getElementsByClassName("close1")[0];

        // When the user clicks the button, open the modal
        btn.onclick = function () {
            modal.style.display = "block";
            return false;
        }

        btn1.onclick = function () {
            createModal.style.display = "block";
            return false;
        }

        // When the user clicks on <span> (x), close the modal
        span.onclick = function () {
            modal.style.display = "none";
        }

        span1.onclick = function () {
            createModal.style.display = "none";
        }

        // When the user clicks anywhere outside of the modal, close it
        window.onclick = function (event) {
            if (event.target == modal) {
                modal.style.display = "none";
            }
        }
        window.onclick = function (event) {
            if (event.target == createModal) {
                createModal.style.display = "none";
            }
        }
    }
    document.addEventListener('DOMContentLoaded', initialize, false);
</script>

<title>CMS Emergency System</title>
<!--implement JQuery tab panel-->
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<!--End implement JQuery tab panel-->
<!--Api Key-->
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC-SUfpR6e3ZBZ9z06cdPOICWb46-0QEXk&libraries=places&extension=.js"></script>
<script>
    google.maps.event.addDomListener(window, 'load', init); /*Right click for context menu*/
    var map;
    function init() {
        //Build Context Menu using Javascript
        function ContextMenu(map, options) {
            options = options || {};

            this.setMap(map);

            this.classNames_ = options.classNames || {};
            this.map_ = map;
            this.mapDiv_ = map.getDiv();
            this.menuItems_ = options.menuItems || [];
            this.pixelOffset = options.pixelOffset || new google.maps.Point(10, -5);
        }

        ContextMenu.prototype = new google.maps.OverlayView();

        ContextMenu.prototype.draw = function () {
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

        ContextMenu.prototype.getVisible = function () {
            return this.isVisible_;
        };

        ContextMenu.prototype.hide = function () {
            if (this.isVisible_) {
                this.menu_.style.display = 'none';
                this.isVisible_ = false;
            }
        };

        ContextMenu.prototype.onAdd = function () {
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

        ContextMenu.prototype.onRemove = function () {
            this.menu_.parentNode.removeChild(this.menu_);
            delete this.mapDiv_;
            delete this.menu_;
            delete this.position_;
        };

        ContextMenu.prototype.show = function (latLng) {
            if (!this.isVisible_) {
                this.menu_.style.display = 'block';
                this.isVisible_ = true;
            }
            this.position_ = latLng;
            this.draw();
        };
        //End context Menu using JavaScript

        //Google Map
        var mapOptions = {
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
            },
        }


        var mapElement = document.getElementById('map');
        var map = new google.maps.Map(mapElement, mapOptions);
        var locations = [];



        //	create the ContextMenuOptions object
        var contextMenuOptions = {};
        contextMenuOptions.classNames = { menu: 'context_menu', menuSeparator: 'context_menu_separator' };

        //	create an array of ContextMenuItem objects
        var menuItems = [];
        menuItems.push({ className: 'context_menu_item', eventName: 'zoom_in_click', label: 'Zoom in' });
        menuItems.push({ className: 'context_menu_item', eventName: 'zoom_out_click', label: 'Zoom out' });
        //	a menuItem with no properties will be rendered as a separator
        menuItems.push({});
        menuItems.push({ className: 'context_menu_item', eventName: 'center_map_click', label: 'Center map here' });
        menuItems.push({ className: 'context_menu_item', eventName: 'Add_info_marker', label: 'Add Info Marker' });
        menuItems.push({ className: 'context_menu_item', eventName: 'Add_parking_marker', label: 'Add Parking Marker' });
        menuItems.push({ className: 'context_menu_item', eventName: 'Add_library_marker', label: 'Add Library Marker' });
        contextMenuOptions.menuItems = menuItems;

        //	create the ContextMenu object
        var contextMenu = new ContextMenu(map, contextMenuOptions);

        //	display the ContextMenu on a Map right click
        google.maps.event.addListener(map, 'rightclick', function (mouseEvent) {
            contextMenu.show(mouseEvent.latLng);
        });

        //	listen for the ContextMenu 'menu_item_selected' event
        google.maps.event.addListener(contextMenu, 'menu_item_selected', function (latLng, eventName) {
            //	latLng is the position of the ContextMenu
            //	eventName is the eventName defined for the clicked ContextMenuItem in the ContextMenuOptions
            switch (eventName) {
                case 'zoom_in_click':
                    map.setZoom(map.getZoom() + 1);
                    break;
                case 'zoom_out_click':
                    map.setZoom(map.getZoom() - 1);
                    break;
                case 'center_map_click':
                    map.panTo(latLng);
                    break;
                case 'Add_info_marker':

                    var marker = new google.maps.Marker({
                        position: latLng,
                        icon: 'https://maps.google.com/mapfiles/kml/shapes/info-i_maps.png',
                        map: map
                    });
                    marker.setMap(map);
                    marker.addListener('click', function () {
                        infowindow.open(map, marker);
                    });
                    break;

                case 'Add_parking_marker':

                    var marker = new google.maps.Marker({
                        position: latLng,
                        icon: 'https://maps.google.com/mapfiles/kml/shapes/parking_lot_maps.png',
                        map: map
                    });
                    marker.setMap(map);
                    marker.addListener('click', function () {
                        infowindow.open(map, marker);
                    });
                    break;

                case 'Add_library_marker':

                    var marker = new google.maps.Marker({
                        position: latLng,
                        icon: 'https://maps.google.com/mapfiles/kml/shapes/library_maps.png',
                        map: map
                    });
                    marker.setMap(map);
                    marker.addListener('click', function () {
                        infowindow.open(map, marker);
                    });
                    break;
            }

            /*
        
                            var infowindow = new google.maps.InfoWindow({
                                content: "Fuck my life"
                            });
        
                            var markertype = 'info'
                            var myLatlng;
                            var marker = new google.maps.Marker({
                                position: latLng,
                                type: markertype,
                                icon: icons[markertype].icon,
                                map: map,
                                title: 'NTU'
                            });
                            marker.setMap(map);
                            marker.addListener('click', function() {
                                infowindow.open(map, marker);
                            });
                            break;*/




        });

        var iconBase = 'https://maps.google.com/mapfiles/kml/shapes/';
        var icons = {
            parking: {
                name: 'parking',
                icon: iconBase + 'parking_lot_maps.png'
            },
            library: {
                name: 'library',
                icon: iconBase + 'library_maps.png'
            },
            info: {
                name: 'info',
                icon: iconBase + 'info-i_maps.png'
            }
        };


        var legend = document.getElementById('legend');
        for (var key in icons) {
            var type = icons[key];
            var name = type.name;
            var icon = type.icon;
            var div = document.createElement('div');
            div.innerHTML = '<img src="' + icon + '"> ' + name;
            legend.appendChild(div);
        }

        map.controls[google.maps.ControlPosition.LEFT_BOTTOM].push(legend);



        //Google Search Map


        // Create the search box and link it to the UI element.
        var input = document.getElementById('pac-input');
        var searchBox = new google.maps.places.SearchBox(input);
        map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

        // Bias the SearchBox results towards current map's viewport.
        map.addListener('bounds_changed', function () {
            searchBox.setBounds(map.getBounds());
        });

        var markers = [];
        // Listen for the event fired when the user selects a prediction and retrieve
        // more details for that place.
        searchBox.addListener('places_changed', function () {
            var places = searchBox.getPlaces();

            if (places.length == 0) {
                return;
            }

            // Clear out the old markers.
            markers.forEach(function (marker) {
                marker.setMap(null);
            });
            markers = [];

            // For each place, get the icon, name and location.
            var bounds = new google.maps.LatLngBounds();
            places.forEach(function (place) {
                if (!place.geometry) {
                    console.log("Returned place contains no geometry");
                    return;
                }
                var icon = {
                    url: place.icon,
                    size: new google.maps.Size(71, 71),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(17, 34),
                    scaledSize: new google.maps.Size(25, 25)
                };

                /*// Create a marker for each place.
                markers.push(new google.maps.Marker({
                    map: map,
                    icon: icon,
                    title: place.name,
                    position: place.geometry.location
                }));*/

                if (place.geometry.viewport) {
                    // Only geocodes have viewport.
                    bounds.union(place.geometry.viewport);
                } else {
                    bounds.extend(place.geometry.location);
                }
            });
            map.fitBounds(bounds);
        });


        //Open Info Window

        var autocomplete = new google.maps.places.Autocomplete(
            input, { placeIdOnly: true });
        autocomplete.bindTo('bounds', map);
        autocomplete.setComponentRestrictions({ country: "SG" });

        map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

        var infowindow = new google.maps.InfoWindow();
        var infowindowContent = document.getElementById('infowindow-content');
        infowindow.setContent(infowindowContent);
        var geocoder = new google.maps.Geocoder;
        var marker = new google.maps.Marker({
            map: map
        });
        marker.addListener('click', function () {
            infowindow.open(map, marker);
        });

        autocomplete.addListener('place_changed', function () {
            infowindow.close();
            infowindow.open(map, marker);
            var place = autocomplete.getPlace();
            if (!place.place_id) {
                return;
            }
            geocoder.geocode({ 'placeId': place.place_id }, function (results, status) {

                if (status !== 'OK') {
                    window.alert('Geocoder failed due to: ' + status);
                    return;
                }
                map.setZoom(11);
                map.setCenter(results[0].geometry.location);

                console.log(results[0].geometry.location.lat());
                console.log(results[0].geometry.location.lng());

                // Set the position of the marker using the place ID and location.
                marker.setPlace({
                    placeId: place.place_id,
                    location: results[0].geometry.location
                });
                marker.setVisible(true);
                infowindowContent.children['place-name'].textContent = place.name;
                infowindowContent.children['place-id'].textContent = place.place_id;
                infowindowContent.children['place-address'].textContent = results[0].formatted_address;
                infowindowContent.children['lat'].textContent = results[0].geometry.location.lat();
                infowindowContent.children['lng'].textContent = results[0].geometry.location.lng();

                document.getElementById('locationTextBox').value = infowindowContent.children['place-address'].textContent;

                infowindow.open(map, marker);
            });
            
        });

        //End Open Info Window



    };

</script>
<form id="IncidentForm" runat="server">
  <!-- The Modal -->
<div id="myModal" class="modal">

    <!-- Modal content -->
    <div class="modal-content">
        <div class="modal-header">
            <span class="close">&times;</span>
            <h2>View Incident Report</h2>
        </div>
        <div class="modal-body">
                <table class="CurrentIncident" width="100%">
                    <tr>
                        <th>Date/Time of Report:</th>
                        <td><asp:Label ID="DateTimeDisplay" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label></td>
                        <th colspan="3"></th>
                    </tr>
                    <tr>
                        <th>Type of Incident:</th>
                        <td><asp:Label ID="incidentType" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label></td>
                        <th>Incident ID:</th>
                        <td><asp:Label ID="IncidentID" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Reporting Person:</th>
                        <td><asp:Label ID="reporterName" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label></td>
                        <th>Contact No:</th>
                        <td><asp:Label ID="contactNumber" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Location:</th>
                        <td><asp:Label ID="Location" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label></td>
                        <th>Postal Code:</th>
                        <td><asp:Label ID="postalCode" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Main Dispatch:</th>
                        <td><asp:Label ID="mainDispatch" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label></td>
                        <th>Assist Type:</th>
                        <td><asp:TextBox id="supportType" TextMode="multiline" Columns="30" Rows="5" runat="server" ReadOnly="True" /></td>
                    </tr>
                    <tr>
                        <th>Description:</th>
                        <td colspan="3"><asp:Label ID="incidentDesc" runat="server" Text="TEMPTXT, REMOVE WHEN CODED"></asp:Label> </td>
                    </tr>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                    <th>Status Log:</th>
                    <td colspan="3">
                        <%--<asp:TextBox id="statusLog" TextMode="multiline" Columns="30" Rows="5" runat="server" ReadOnly="True" Width="452px" />--%> 
                        <%--<textarea rows="7" cols="90" disabled>
                            [12/1/2017 00:00:00] Dispatched SCDF - FireFighting Crew
                            [12/1/2017 00:00:05] SPF - Community Engagement
                            [12/1/2017 00:05:08] FireFighting crew arrived location
                            [12/1/2017 00:07:10] Black smoke raging and spreading
                            [12/1/2017 00:08:34] SPF crew arrived location
                            [12/1/2017 00:09:43] Firefighters used 3 water jets to penetrate the burning stadium
                            [12/1/2017 00:10:00] The fire was brought under control
                            [12/1/2017 00:15:00] Conducting search and rescue operations within the stadium
                            [12/1/2017 00:30:00] No casualty found
                        </textarea>--%>
                    </td>
         
                    <tr>
                        <th>Add Status:</th>
                        <td colspan="3"><input type="text" name="firstname" size="90" />&nbsp;<button>Add Status</button></td>
                    </tr>
                </table>
        </div>
        <div class="modal-footer">
        </div>
    </div>

</div>


<!-- The Modal Create Incident -->
<div id="CreateIncidentDialogBox" class="modal">

    <!-- Modal content Create Incident -->
    <div class="modal-content">
        <div class="modal-header">
            <span class="close1">&times;</span>
            <h2>Create Incident Report</h2>
        </div>
        <div class="modal-body">
            <%--<form id="CreateIncidentForm" runat="server">--%>
                <table class="CreateIncident" width="100%">
                    <tr>
                        <th>Type of Incident:</th>
                        <td colspan="3">
                            <asp:DropDownList ID="typeOfIncidentDDL" runat="server">
                                <asp:ListItem Text="Fire Outbreak" Value="Fire Outbreak" />
                                <asp:ListItem Text="Dengue Outbreak" Value="Dengue Outbreak" />
                                <asp:ListItem Text="Earthquake" Value="Earthquake" />
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th>Reporting Person:</th>
                        <td><asp:TextBox ID="reportPersonTextBox" runat="server"></asp:TextBox></td>

                        <th style="text-align: right;padding-right: 13px;">Contact No:</th>
                        <td><asp:TextBox ID="contactNoTextBox" runat="server" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Location:</th>
                        <td><asp:TextBox ID="locationTextBox" runat="server" ClientIDMode="Static"></asp:TextBox></td>
                        
                        <th style="text-align: right;padding-right: 13px;">Postal Code:</th>
                        <td><asp:TextBox ID="postalCodeTextBox" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th>Main Dispatch:</th>
                        <td colspan="3">
                            <asp:DropDownList ID="MainDispatchDDL" runat="server">
                                <asp:ListItem Text="SCDF - Emergency Ambulance" Value="Emergency Ambulance" />
                                <asp:ListItem Text="SCDF - Rescue and Evacuation" Value="Rescue and Evacuation" />
                                <asp:ListItem Text="SCDF - FireFighting" Value="FireFighting" />
                                <asp:ListItem Text="SCDF - Hazmat Responder" Value="Hazmat Responder" />
                                <asp:ListItem Text="SPF - Protective Sercurity" Value="Protective Sercurity" />
                                <asp:ListItem Text="SPF - Police Tactical Troop" Value="Police Tactical Troop" />
                                <asp:ListItem Text="SPF - Neighbouring Policing" Value="Neighbouring Policing" />
                                <asp:ListItem Text="SPF - Community Engagement Policing" Value="Community Engagement Policing" />
                                <asp:ListItem Text="SAF - Medical Unit" Value="Medical Unit" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th rowspan="2">Assist Type:</th>
                        <th style="text-align: left;">SCDF</th>
                        <th style="text-align: left;">SPF</th>
                        <th style="text-align: left;">SAF</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBoxList ID="assistTypeCheckBoxList" runat="server" Width="369px">
                                <asp:ListItem Text="Emergency Ambulance" Value="1" ></asp:ListItem>
                                <asp:ListItem Text="Rescue and Evacuation" Value="2" ></asp:ListItem>
                                <asp:ListItem Text="FireFighting" Value="3" ></asp:ListItem>
                                <asp:ListItem Text="Hazmat Responder" Value="4" ></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <td>
                           <asp:CheckBoxList ID="CheckBoxList1" runat="server" Width="369px">
                               <asp:ListItem Text="Protective Sercurity" Value="5" ></asp:ListItem>
                               <asp:ListItem Text="Police Tactical Troop" Value="6" ></asp:ListItem>
                               <asp:ListItem Text="Neighbouring Policing" Value="7" ></asp:ListItem> 
                               <asp:ListItem Text="Community Engagement Policing" Value="8" ></asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <td>
                            <asp:CheckBoxList ID="CheckBoxList2" runat="server" Width="369px">
                                <asp:ListItem Text="Medical Unit" Value="9" ></asp:ListItem> 
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <th>Description:</th>
                        <td colspan="3"><asp:TextBox ID="descriptionTextBox" runat="server" Height="86px" Width="937px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="4"><center><asp:Button ID="submit" Text="Create Incident" runat="server" OnClick="CreateIncidentButton" Height="29px"/></center></td>
                    </tr>
                </table>

            <%--</form>--%>
        </div>
        <div class="modal-footer">
        </div>
    </div>
</div>
</form>
<div class="wrapMap" id="wrapmap">

    <div id="leftpanel" style="position:fixed;">
        <div id="leftsidepanel" class="leftpanel wrapper">
            <img id="leftpanelicon" src="../Images/arrow-down-c.png" style="-webkit-transform: rotate(180deg);     /* Chrome and other webkit browsers */
  -moz-transform: rotate(180deg);        /* FF */
  -o-transform: rotate(180deg);          /* Opera */
  -ms-transform: rotate(180deg);         /* IE9 */
  transform: rotate(180deg);  " onclick="w3_openleft()" />
        </div>
        <div id="hiddenleftpanel" class="leftpanel wrapper">
            <img id="closepanelicon" src="../Images/arrow-down-c.png" onclick="w3_closeleft()" />
            <div style="position: inherit;display: none;height:100%;overflow-y:scroll;" id="mySidenav">

                <div id="livefeed">
                        <div id="fbLiveFeed">
                            <asp:Button ID="Button1" Text="Login to Facebook" onClick="myFacebookLogin()">Login to Facebook!</asp:Button>
                            <asp:Button ID="Button2" Text="Post to Facebook" onClick="myFacebookPost()">Post to Facebook!</asp:Button>

                        </div>

                        <div id="twitterLiveFeed">


                        </div>

                </div>
            </div>
        </div>
    </div>


    <div id="rightpanel">
        <input id="pac-input" class="controls" type="text" placeholder="Search Box" style="width: 300px;">
        <div id="map">
        </div>
        <div id="infowindow-content">
      <span id="place-name"  class="title"></span><br>
      Place ID <span id="place-id"></span><br>
      <a id="CreateIncident">Create Incident</a><br>
      <span id="lat">Latitude: </span><br>
      <span id="lng">Longtidue: </span><br>
      <span id="place-address"></span>
    </div>
        <div id="legend"><h4>Legend</h4></div>
        <div id="Incidents" style="margin: 10px;">
            <div id="tabs">
                <ul class="nav nav-tabs">
                    <li><a onclick="tab1();">Current Incidents CANNNNN</a></li>
                    <li><a onclick="tab2();">Resolved Incidents</a></li>
                </ul>
                <div id="tabs-1" style="width: 100%;">
                    <table class="table table-striped table-hover " border="5">
                        <thead>
                            <tr>
                                <th>
                                    #
                                </th>
                                <th>
                                    Incident Type
                                </th>
                                <th>
                                    Description
                                </th>
                                <th>
                                    Priority
                                </th>
                                <th>
                                    Status
                                </th>
                                <th>
                                    Location
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    Large Fire
                                </td>
                                <td>
                                    Factory on fire ggwp!
                                </td>
                                <td class="alert-warning">
                                    Medium
                                </td>
                                <td></td>
                                <td>
                                    Yishun
                                </td>
                                <td>
                                    <a id="ViewDetails">Click here to view.</a>
                                </td>
                                <td>
                                    <img id="Update" src="../Images/update.png"/>
                                </td>
                                <td>
                                    <img id="CreateIncident" src="../Images/create.png"/>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2
                                </td>
                                <td>
                                    Oil Spillage
                                </td>
                                <td>
                                    Siao Liao!
                                </td>
                                <td class="alert-danger">
                                    <strong>High</strong>
                                </td>
                                <td></td>
                                <td>
                                    Changi
                                </td>
                                <td>
                                    <a id="ViewDetails">Click here to view.</a>
                                </td>
                                <td>
                                    <img id="Update" src="../Images/update.png" />
                                </td>
                                <td>
                                    <img id="CreateIncident" src="../Images/create.png" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3
                                </td>
                                <td>
                                    Haze
                                </td>
                                <td>
                                    Everywhere!
                                </td>
                                <td class="alert-success">
                                    Low
                                </td>
                                <td></td>
                                <td>
                                    Bedok
                                </td>
                                <td>
                                    <a id="ViewDetails">Click here to view.</a>
                                </td>
                                <td>
                                    <img id="Update" src="../Images/update.png" />
                                </td>
                                <td>
                                    <img id="CreateIncident" src="../Images/create.png" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4
                                </td>
                                <td>
                                    Air Pollution
                                </td>
                                <td>
                                    Around East Area
                                </td>
                                <td class="alert-danger">
                                    <strong>High</strong>
                                </td>
                                <td></td>
                                <td>
                                    Ang Mo Kio
                                </td>
                                <td>
                                    <a id="ViewDetails">Click here to view.</a>
                                </td>
                                <td>
                                    <img id="Update" src="../Images/update.png" />
                                </td>
                                <td>
                                    <img id="CreateIncident" src="../Images/create.png" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="tabs-2" style="display:none;width: 100%;">
                    <table class="table table-striped table-hover " border="5">
                        <thead>
                            <tr>
                                <th>
                                    #
                                </th>
                                <th>
                                    Incident Type
                                </th>
                                <th>
                                    Description
                                </th>
                                <th>
                                    Priority
                                </th>
                                <th>
                                    Status
                                </th>
                                <th>
                                    Location
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                                <th>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    Large Fire
                                </td>
                                <td>
                                    Factory on fire ggwp!
                                </td>
                                <td class="alert-warning">
                                    Medium
                                </td>
                                <td></td>
                                <td>
                                    Yishun
                                </td>
                                <td>
                                    <a id="ViewDetails">Click here to view.</a>
                                </td>
                                <td>
                                    <img id="Update" src="../Images/update.png" />
                                </td>
                                <td>
                                    <img id="CreateIncident" src="../Images/create.png" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <div id="rightsidepanel" style="position: fixed;right:0;display: inline-block;">
        <div id="openrightpanel" class="rightpanel wrapper">
            <img id="rightpanelicon" src="../Images/arrow-down-c.png" onclick="w3_openright()" />
        </div>
        <div id="closerightpanel" style="display:none;" class="rightpanel wrapper">
            <img id="closerightpanelicon" src="../Images/arrow-down-c.png" style="-webkit-transform: rotate(180deg);     /* Chrome and other webkit browsers */
  -moz-transform: rotate(180deg);        /* FF */
  -o-transform: rotate(180deg);          /* Opera */
  -ms-transform: rotate(180deg);         /* IE9 */
  transform: rotate(180deg);  " onclick="w3_closeright()" />

            <div style="position:inherit;display:none;" id="myRightSidenav">
                <div id="notepad">
                    <textarea placeholder="Enter your notes here"></textarea>
                </div>
            </div>
        </div>
    </div>

</div>



</asp:Content>
