﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CMSEmergencySystem.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script runat="server" type="text/c#">
        protected void TimerFB_Tick(object sender, EventArgs e)
        {

            RefreshFBFeed();// return
            // byID of your panel update that panel
        }
        protected void TimerTwitter_Tick(object sender, EventArgs e)
        {
            RefreshTwitterFeed(url, query);
        }
    </script>

    <script>
        function CheckedChanged() {
            for (var i = 0; i < fire.length; i++) {
                if (document.getElementById("showFire").checked == true)
                    fire[i].setVisible(true);
                else
                    fire[i].setVisible(false);
            }
            for (i = 0; i < riot.length; i++) {
                if (document.getElementById("showRiot").checked == true)
                    riot[i].setVisible(true);
                else
                    riot[i].setVisible(false);
            }
            for (i = 0; i < caraccident.length; i++) {
                if (document.getElementById("showCarAccident").checked == true)
                    caraccident[i].setVisible(true);
                else
                    caraccident[i].setVisible(false);
            }
            for (i = 0; i < terrorist.length; i++) {
                if (document.getElementById("showTerrorist").checked == true)
                    terrorist[i].setVisible(true);
                else
                    terrorist[i].setVisible(false);
            }
            //NEA Markers
            for (var w = 0; w < weatherList.length; w++) {
                if (document.getElementById("weatherCheckBox").checked == true)
                    weatherList[w].setVisible(true);
                else
                    weatherList[w].setVisible(false);
            }
        }
        //function toggleBomb() {
        //    for (var i = 0; i < pushBombShelter.length; i++) {
        //        //console.log(listOfBombShelter.length);
        //        if (document.getElementById("bombShelterCheckBox").checked == true)
        //            pushBombShelter[i].setVisible(true);
        //        else
        //            pushBombShelter[i].setVisible(false);
        //    }
        //}
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
            document.getElementById("rightpanel").style.marginRight = (document.getElementById("closerightpanel").offsetWidth) - 50 + "px";
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
            document.getElementById("tabs-3").style.display = "none";
        }
        function tab2() {
            document.getElementById("tabs-1").style.display = "none";
            document.getElementById("tabs-2").style.display = "inline-block";
            document.getElementById("tabs-3").style.display = "none";
        }
        function tab3() {
            document.getElementById("tabs-1").style.display = "none";
            document.getElementById("tabs-2").style.display = "none";
            document.getElementById("tabs-3").style.display = "inline-block";
        }
    </script>

    <script>
        function initialize() {
            // Get the modal
            var modal = document.getElementById('myModal');
            var createModal = document.getElementById('CreateIncidentDialogBox');

            // Get the button that opens the modal
            var btn1 = document.getElementById("CreateIncident");

            var span = document.getElementsByClassName("close")[0];
            var span1 = document.getElementsByClassName("close1")[0];

            btn1.onclick = function () {
                if (document.getElementById('infowindow-content').children["CreateIncident"].textContent == "Create Incident") {
                    createModal.style.display = "block";
                    document.getElementById('LatInfo').value = window.defaultPlaceGResult.latitude;
                    document.getElementById('LngInfo').value = window.defaultPlaceGResult.longitude;
                }
                else if (document.getElementById('infowindow-content').children["CreateIncident"].textContent == "View Incident") {
                    var table = document.getElementById("MainContent_GridData");
                    for (var i = 1; i < table.rows.length; i++) {
                        if (state == table.rows[i].cells[0].innerHTML) {
                            document.getElementById("MainContent_GridData").rows[i].cells[5].children[0].click()
                        }
                    }
                }
                console.log("MAP_ID: " + state);
                return false;
            }
            span.onclick = function () {
                modal.style.display = "none";
            }

            span1.onclick = function () {
                createModal.style.display = "none";
            }
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

        function displayModal() {
            document.getElementById('myModal').style.display = "block";
        }

        function closeModal() {
            document.getElementById('CreateIncidentDialogBox').style.display = "none";
        }

        function replaceDefaultMarker(incident) {
            closeModal();
            var type = document.getElementById("<%=typeOfIncidentDDL.ClientID%>");
            var typeStr = type.options[type.selectedIndex].value;
            console.log("replace Type",typeStr);
            var marker = CMSEmergencySystem.Map.ReplaceFirstMarker(typeStr, incident.NewIncidentID, incident);
            if (typeStr == "Fire Outbreak")
                fire.push(marker);
            else if (typeStr == "Car Accident")
                caraccident.push(marker);
            else if (typeStr == "Riot Outbreak")
                riot.push(marker);
            else if (typeStr == "Terrorist")
                terrorist.push(marker);
        }

    </script>
    <script>
        function ViewIncidentButtonTest() {
            var modal = document.getElementById('myModal');

            // Get the <span> element that closes the modal
            var spanTest = document.getElementsByClassName("close")[0];

            // When the user clicks the button, open the modal
            viewIncidentTest.onclick = function () {
                modal.style.display = "block";
                return false;
            }
            // When the user clicks on <span> (x), close the modal
            spanTest.onclick = function () {
                modal.style.display = "none";
            }
            // When the user clicks anywhere outside of the modal, close it
            window.onclick = function (event) {
                if (event.target == modal) {
                    modal.style.display = "none";
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
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBTdSKDpeyLxGmVqZSkMzxyX2X0341nbFQ&libraries=places&extension=.js"></script>
    <script src="/Scripts/map.js" type="text/javascript"></script>
    var list;
    <script>
        var fire = [];
        var caraccident = [];
        var riot = [];
        var terrorist = [];
        var weatherList = [];
        var dengueLayer;
        var listOfBombShelter = [];
        var pushBombShelter = [];
        var list = [];

        google.maps.event.addDomListener(window, 'load', init);

        function init() {
            CMSEmergencySystem.Map.Initialize("map", "pac-input", "infowindow-content");
            CMSEmergencySystem.Map.AddDefaultPlaceListener(onPlaceSelected);
            CMSEmergencySystem.Map.AddPlaceSelectedListener(onPlaceSelected);
            CMSEmergencySystem.Map.AddDefaultPlaceListener(cacheDefaultPlaceGResult);
            document.getElementById('LatInfo').value = CMSEmergencySystem.Map._InfoWindowContent.children["lat"].textContent;
            document.getElementById('LngInfo').value = CMSEmergencySystem.Map._InfoWindowContent.children["lng"].textContent;
            console.log(document.getElementById('LatInfo').value);
            //Load Dengue KML
            dengueLayer = CMSEmergencySystem.Map.LoadDengue();
            //NEA Marker Function
            <%
            for (var i = 0; i < weather2hrArray.GetLength(0); i++)
            {%>
            var location = new google.maps.LatLng(parseFloat(<%=weather2hrArray[i, 1]%>), parseFloat(<%=weather2hrArray[i, 2]%>));
            var forecast = "<%=weather2hrArray[i,3]%>";

            var weatherMarker = CMSEmergencySystem.Map.WeatherAddMarker(location, forecast);
            weatherList.push(weatherMarker);
            <%}%>

            var icon;
            $.ajax("/IncidentServlet.aspx", {
                success: function (data) {
                    list = JSON.parse(data);
                    console.log(list);
                    for (var i = 0; i < list.length; i++) {
                        var incident = list[i];
                        //console.log("Retrieve var from incident");
                        if (incident.Status == "Unresolved") {
                            //console.log("if statement");
                            incident.formatted_address = incident.Location;
                            incident.latitude = incident.Latitude;
                            incident.longitude = incident.Longitude;
                            var marker = CMSEmergencySystem.Map.AddMarker(new google.maps.LatLng(incident.Latitude, incident.Longitude),
                                    incident.TypeOfIncident, incident.NewIncidentID, incident);
                            if (incident.TypeOfIncident == "Fire Outbreak")
                                fire.push(marker);
                            else if (incident.TypeOfIncident == "Car Accident")
                                caraccident.push(marker);
                            else if (incident.TypeOfIncident == "Riot Outbreak")
                                riot.push(marker);
                            else if (incident.TypeOfIncident == "Terrorist")
                                terrorist.push(marker);
                        }
                    }
                    //alert("go pass through here");
                    //CMSEmergencySystem.Map.ClearMarker();
                },
                error: function () { }
            });
            //CMSEmergencySystem.Map.AddDefaultPlaceListener(cachePlace);
            //$.ajax("/BombShelterServlet.aspx", {
            //    success: function (data) {
            //        //console.log(JSON.parse(data));
            //        //var x ='[{"Location":"AAAAAAA","Latitude":1.345555,"Longitude":103.932465,"Postal":529757,"Description":"AAAAAA","Address":"AAAAA"}]';
            //        listOfBombShelter = JSON.parse(data);
            //        //console.log(listOfBombShelter)
            //        for (var i = 0; i < listOfBombShelter.length; i++) {
            //            var BombShelter = listOfBombShelter[i];
            //            //console.log("Retrieve var from incident");
            //            //console.log("if statement");
            //            // incident.formatted_address = incident.Location;
            //            BombShelter.latitude = BombShelter.Latitude;
            //            BombShelter.longitude = BombShelter.Longitude;
            //            var marker = CMSEmergencySystem.Map.BombShelterAddMarker(new google.maps.LatLng(BombShelter.Latitude, BombShelter.Longitude));
            //            marker.setVisible(false);
            //            pushBombShelter.push(marker);
            //            //new google.maps.LatLng(incident.Latitude, incident.Longitude), Map,

            //        }
            //        //alert("go pass through here");
            //        //CMSEmergencySystem.Map.ClearMarker();
            //    },
            //    error: function () { }
            //});
        }



    function cacheDefaultPlaceGResult(marker, geocodeResult) {
        window.defaultPlaceGResult = geocodeResult;
    }

    function onPlaceSelected(marker, geocodeResult) {
        // Whenever a place is selected this listener will be called
        // Retrieve the place from marker._Place
        document.getElementById('locationTextBox').value = geocodeResult.formatted_address ? geocodeResult.formatted_address : "";
        if (fire.indexOf(marker) != -1 || caraccident.indexOf(marker) != -1 || riot.indexOf(marker) != -1 || terrorist.indexOf(marker) != -1) {
            document.getElementById('infowindow-content').children["CreateIncident"].textContent = "View Incident"
        }
        else {
            document.getElementById('infowindow-content').children["CreateIncident"].textContent = "Create Incident"
        }
    }

    /*var place, gresult;
    function cachePlace(marker, geocodeResult) {
        place = marker._Place;
        geocodeResult = gresult;
    }*/

    //Dengue Toggle Function
    function toggleDengue() {
        if (dengueLayer.getMap() == null) {
            dengueLayer.setMap(CMSEmergencySystem.Map._Map);
        }
        else {
            dengueLayer.setMap(null);
        }
    }
    </script>

    <form name="IncidentForm" id="IncidentForm" runat="server">
        <!-- The Modal -->
        <div id="myModal" class="modal">

            <!-- Modal content -->
            <div class="modal-content">
                <div class="modal-header">
                    <span class="close">&times;</span>
                    <h3>View Incident Report</h3>
                </div>
                <div class="modal-body">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <table class="CurrentIncident">
                                <tr>
                                    <th>Date / Time of Report : </th>
                                    <td>
                                        <asp:Label ID="DateTimeDisplay" runat="server" Text=""></asp:Label></td>
                                    <th colspan="3"></th>
                                </tr>
                                <tr>
                                    <th>Type of Incident : </th>
                                    <td>
                                        <asp:Label ID="incidentType" runat="server" Text=""></asp:Label></td>
                                    <th>Incident ID : </th>
                                    <td>
                                        <asp:Label ID="IncidentID" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Reporting Person : </th>
                                    <td>
                                        <asp:Label ID="reporterName" runat="server" Text=""></asp:Label></td>
                                    <th>Contact No : </th>
                                    <td>
                                        <asp:Label ID="contactNumber" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Location : </th>
                                    <td>
                                        <asp:Label ID="Location" runat="server" Text=""></asp:Label></td>
                                    <th>Postal Code : </th>
                                    <td>
                                        <asp:Label ID="postalCode" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <th>Main Dispatch : </th>
                                    <td>
                                        <asp:Label ID="mainDispatch" runat="server" Text=""></asp:Label></td>
                                    <th>Assist Type : </th>
                                    <td>
                                        <asp:TextBox ID="supportType" TextMode="multiline" Columns="30" Rows="5" runat="server" ReadOnly="True" /></td>
                                </tr>
                                <tr>
                                    <th>Description : </th>
                                    <td colspan="3">
                                        <asp:Label ID="incidentDesc" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <th>Status Log : </th>
                                    <td>
                                        <asp:TextBox ID="statusLog" TextMode="multiline" Columns="30" Rows="5" runat="server" ReadOnly="True" />
                                    </td>
                                </tr>

                                <tr>
                                    <th>Update Status : </th>
                                    <td>
                                        <asp:DropDownList ID="statusUpdate" runat="server">
                                            <asp:ListItem Text="Unresolved" Value="Unresolved" />
                                            <asp:ListItem Text="Resolved" Value="Resolved" />
                                        </asp:DropDownList></td>
                                </tr>

                                <tr>
                                 
                                    <td>
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Style="padding: 5px 10px;" Text="Update" OnClick="UpdateStatusOnClick" /></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                    <h3>Create Incident Report</h3>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel UpdateMode="Conditional" ID="UpdateCreate" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="LatInfo" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="LngInfo" runat="server" ClientIDMode="Static" />
                            <table class="CreateIncident">
                                <tr>
                                    <th>Type of Incident : </th>
                                    <td>
                                        <asp:DropDownList style="height: 1%;padding: 5px;width: auto;" CssClass="form-control" ID="typeOfIncidentDDL" runat="server">
                                            <asp:ListItem Text="Fire Outbreak" Value="Fire Outbreak" />
                                            <asp:ListItem Text="Riot Outbreak" Value="Riot Outbreak" />
                                            <asp:ListItem Text="Car Accident" Value="Car Accident" />
                                            <asp:ListItem Text="Terrorist" Value="Terrorist" />
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <th>Reporting Person : </th>
                                    <td>
                                        <asp:TextBox style="width:100%;" ID="reportPersonTextBox" runat="server"></asp:TextBox></td>

                                    <th>Contact No:</th>
                                    <td>
                                        <asp:TextBox style="width:100%;" ID="contactNoTextBox" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>Location : </th>
                                    <td>
                                        <asp:TextBox style="width:100%;" ID="locationTextBox" runat="server" ClientIDMode="Static"></asp:TextBox></td>

                                    <th>Postal Code : </th>
                                    <td>
                                        <asp:TextBox style="width:100%;" ID="postalCodeTextBox" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <th>Main Dispatch : </th>
                                    <td>
                                        <asp:DropDownList style="height: 1%;padding: 5px;width: auto;" CssClass="form-control" ID="MainDispatchDDL" runat="server">
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
                                    <th>Assist Type : </th>
                                </tr>
                                <tr>
                                    <th style="text-align: left;">SCDF</th>
                                    <th style="text-align: left;">SPF</th>
                                    <th style="text-align: left;">SAF</th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList ID="assistTypeCheckBoxList" runat="server">
                                            <asp:ListItem Text="Emergency Ambulance" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Rescue and Evacuation" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="FireFighting" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Hazmat Responder" Value="4"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                    <td>
                                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                                            <asp:ListItem Text="Protective Sercurity" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Police Tactical Troop" Value="6"></asp:ListItem>
                                            <asp:ListItem Text="Neighbouring Policing" Value="7"></asp:ListItem>
                                            <asp:ListItem Text="Community Engagement Policing" Value="8"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                    <td>
                                        <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                                            <asp:ListItem Text="Medical Unit" Value="9"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                <tr>
                                    <th>Description : </th>
                                    <td><asp:TextBox style="width:100%;" ID="descriptionTextBox" runat="server"></asp:TextBox></td>
                                    <td><asp:Button ID="submit" style="padding: 5px 10px;" Text="Create Incident" runat="server"  CssClass="btn btn-primary"  OnClick="CreateIncidentButton" /></td>
                                </tr>
                            </table>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div class="modal-footer">
                    </div>
                </div>
            </div>
            <div class="wrapMap" id="wrapmap">

                <div id="leftpanel" style="position: fixed;">
                    <div id="leftsidepanel" class="leftpanel wrapper">
                        <img id="leftpanelicon" src="../Images/arrow-down-c.png" style="-webkit-transform: rotate(180deg); /* chrome and other webkit browsers */
  -moz-transform: rotate(180deg); /* ff */
  -o-transform: rotate(180deg); /* opera */
  -ms-transform: rotate(180deg); /* ie9 */
  transform: rotate(180deg);"
                            onclick="w3_openleft()" />
                    </div>
                    <div id="hiddenleftpanel" class="leftpanel wrapper">
                        <img id="closepanelicon" src="../Images/arrow-down-c.png" onclick="w3_closeleft()" />
                        <div style="position: inherit; display: none; height: 100%;" id="mySidenav">

                            <div id="livefeed">
                                <div style="background-color: #3b5998; height: auto;">
                                    <img src="Images/facebookicon.png" style="height: 40px; width: auto;" />
                                    FACEBOOK
                                </div>
                                <div class="LiveFeedCSS">
                                    <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanelFBLiveFeed" class="feed" runat="server">
                                        <ContentTemplate>
                                            <asp:Timer runat="server" id="TimerFB" Interval="10000" OnTick="TimerFB_Tick"></asp:Timer>
                                            <div id="fbLiveFeed" runat="server">
                                                <li id="li1">
                                                    <div id="div1" class="status">
                                                        <p id="pmsg1" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta1" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li2">
                                                    <div id="div2" class="status">
                                                        <p id="pmsg2" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta2" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li3">
                                                    <div id="div3" class="status">
                                                        <p id="pmsg3" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta3" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li4">
                                                    <div id="div4" class="status">
                                                        <p id="pmsg4" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta4" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li5">
                                                    <div id="div5" class="status">
                                                        <p id="pmsg5" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta5" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li6">
                                                    <div id="div6" class="status">
                                                        <p id="pmsg6" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta6" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li7">
                                                    <div id="div7" class="status">
                                                        <p id="pmsg7" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta7" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li8">
                                                    <div id="div8" class="status">
                                                        <p id="pmsg8" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta8" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li9">
                                                    <div id="div9" class="status">
                                                        <p id="pmsg9" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta9" runat="server" class="meta"></p>
                                                </li>
                                                <li id="li10">
                                                    <div id="div10" class="status">
                                                        <p id="pmsg10" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="pmeta10" runat="server" class="meta"></p>
                                                </li>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="background-color: #1da1f2; height: auto;">
                                    <img src="Images/twittericon.png" style="height: 40px; width: auto;" />
                                    TWITTER
                                </div>
                                <div class="LiveFeedCSS">
                                    <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel4" class="feed" runat="server">
                                        <ContentTemplate>
                                            <asp:Timer runat="server" id="TimerTwitter" Interval="10000" OnTick="TimerTwitter_Tick"></asp:Timer>
                                            <div id="twitterLiveFeed" runat="server">
                                                <li id="twitterli1">
                                                    <div id="twitterdiv1" class="status">
                                                        <p id="twitterpmsg1" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta1" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli2">
                                                    <div id="twitterdiv2" class="status">
                                                        <p id="twitterpmsg2" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta2" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli3">
                                                    <div id="twitterdiv3" class="status">
                                                        <p id="twitterpmsg3" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta3" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli4">
                                                    <div id="twitterdiv4" class="status">
                                                        <p id="twitterpmsg4" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta4" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli5">
                                                    <div id="twitterdiv5" class="status">
                                                        <p id="twitterpmsg5" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta5" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli6">
                                                    <div id="twitterdiv6" class="status">
                                                        <p id="twitterpmsg6" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta6" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli7">
                                                    <div id="twitterdiv7" class="status">
                                                        <p id="twitterpmsg7" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta7" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli8">
                                                    <div id="twitterdiv8" class="status">
                                                        <p id="twitterpmsg8" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta8" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli9">
                                                    <div id="twitterdiv9" class="status">
                                                        <p id="twitterpmsg9" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta9" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli10">
                                                    <div id="twitterdiv10" class="status">
                                                        <p id="twitterpmsg10" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta10" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli11">
                                                    <div id="div11" class="status">
                                                        <p id="twitterpmsg11" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta11" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli12">
                                                    <div id="div12" class="status">
                                                        <p id="twitterpmsg12" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta12" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli13">
                                                    <div id="div13" class="status">
                                                        <p id="twitterpmsg13" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta13" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli14">
                                                    <div id="div14" class="status">
                                                        <p id="twitterpmsg14" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta14" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli15">
                                                    <div id="div15" class="status">
                                                        <p id="twitterpmsg15" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta15" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli16">
                                                    <div id="div16" class="status">
                                                        <p id="twitterpmsg16" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta16" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli17">
                                                    <div id="div17" class="status">
                                                        <p id="twitterpmsg17" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta17" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli18">
                                                    <div id="div18" class="status">
                                                        <p id="twitterpmsg18" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta18" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli19">
                                                    <div id="div19" class="status">
                                                        <p id="twitterpmsg19" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta19" runat="server" class="meta"></p>
                                                </li>
                                                <li id="twitterli20">
                                                    <div id="div20" class="status">
                                                        <p id="twitterpmsg20" runat="server" class="message"></p>
                                                    </div>
                                                    <p id="twitterpmeta20" runat="server" class="meta"></p>
                                                </li>

                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="rightpanel">
                    <input id="pac-input" class="controls" type="text" placeholder="Search Box" style="top: 10px; width: 300px;">
                    <div id="map"></div>
                    <div id="infowindow-content">
                        <span id="place-address" class="title"></span><br />
                        <span id="place-id"></span>
                        <span id="lat"></span><br />
                        <span id="lng"></span><br />
                        <%--<span id="place-address"></span>--%><br />
                        <a id="CreateIncident" style="font-weight: bold;text-decoration: underline;">Create Incident</a>
                    </div>
                    <div id="legend">
                        <h4>Legend</h4>
                        <table style="text-align: center;">
                            <tr>
                                <td>
                                    <input type="checkbox" id="showCarAccident" name="caraccident" onclick="CheckedChanged();" checked /></td>
                                <td>
                                    <input type="checkbox" id="showFire" name="showfire" onclick="CheckedChanged();" checked /></td>
                                <td>
                                    <input type="checkbox" id="showRiot" name="riot" onclick="CheckedChanged();" checked /></td>
                                <td>
                                    <input type="checkbox" id="showTerrorist" name="terrorist" onclick="CheckedChanged();" checked /></td>
                                <td>
                                    <input type="checkbox" id="weatherCheckBox" name="weatherCheckBox" onclick="CheckedChanged();" /></td>
                                <td>
                                    <input type="checkbox" id="dengueCheckBox" name="dengueCheckBox" onclick="toggleDengue();" /></td>
                                 <td>
                                    <input type="checkbox" id="bombShelterCheckBox" name="bombShelterCheckBox" onclick="toggleBomb();"/></td>
                            </tr>
                            <tr>
                                <td>
                                    <img src="/Icons/caraccident.png" style="width: 40px; height: 40px;" /></td>
                                <td>
                                    <img src="/Icons/Fire.png" style="width: 40px; height: 40px;" /></td>
                                <td>
                                    <img src="/Icons/riot.png" style="width: 40px; height: 40px;" /></td>
                                <td>
                                    <img src="/Icons/terrorist.png" style="width: 40px; height: 40px;" /></td>
                                <td>
                                    <img src="/Icons/weather.png" style="width: 40px; height: 40px;" /></td>
                                <td>
                                    <img src="/Icons/mosquito.png" style="width: 40px; height: 40px;" /></td>
                                <td><img src = "/Icons/bombshelterBig.png"style="width: 40px;height:40px;"/></td>
                            </tr>
                            <tr>
                                <td>Accident</td>
                                <td>Fire</td>
                                <td>Riot</td>
                                <td>Terrorist</td>
                                <td>Weather</td>
                                <td>Dengue</td>
                                <td>Bomb Shelter</td>
                            </tr>
                        </table>

                    </div>
                    <div id="Incidents" style="margin: 10px;">
                        <div id="tabs">
                            <ul class="nav nav-tabs">
                                <li><a onclick="tab1();">Current Incidents</a></li>
                                <li><a onclick="tab2();">Resolved Incidents</a></li>
                                <li><a onclick="tab3();">NEA Data</a></li>
                            </ul>
                            <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                            <div style="padding: 5px; border: 1px solid #dfd7ca;">
                                <asp:TextBox ID="searchResult" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="sendQuery" runat="server" Text="Search" OnClick="sendQuery_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="clearQuery" runat="server" Text="Clear" OnClick="clearQuery_Click" CssClass="btn btn-primary" />
                            </div>
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                            <div id="tabs-1" style="width: 100%;">
                                <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <div class="gridViewTable">
                                            <asp:GridView ID="GridData" runat="server" AutoGenerateColumns="False" OnRowCommand="ViewPendingIncident_RowCommand"
                                                Width="100%" CssClass="table table-striped table-hover">
                                                <Columns>
                                                    <asp:BoundField DataField="IncidentId" HeaderText="Id" />
                                                    <asp:BoundField DataField="dateTime" HeaderText="Date/Time" />
                                                    <asp:BoundField DataField="IncidentType" HeaderText="IncidentType" />
                                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button ID="VI" Text="View Incident" CommandName="Select" runat="server" return="false" CssClass="btn btn-default" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                  
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div id="tabs-2" style="display: none; width: 100%;">
                                <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="GridData2" runat="server" AutoGenerateColumns="False" OnRowCommand="ViewResolvedIncident_RowCommand"
                                            Width="100%" CssClass="table table-striped table-hover">
                                            <Columns>
                                                <asp:BoundField DataField="IncidentId" HeaderText="Id" />
                                                <asp:BoundField DataField="dateTime" HeaderText="Date/Time" />
                                                <asp:BoundField DataField="IncidentType" HeaderText="IncidentType" />
                                                <asp:BoundField DataField="Status" HeaderText="Status" />
                                                <asp:BoundField DataField="Location" HeaderText="Location" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:Button ID="VI" ClientIDMode="Static" Text="View Incident" CommandName="Select" runat="server" return="false" CssClass="btn btn-default" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div id="tabs-3" style="display: none; width: 100%;">
                                <table class="table table-striped table-hover" style="border: 1px solid #dfd7ca;">
                                    <tr>
                                        <td>
                                            <asp:Label ID="forecastLabel" runat="server" Text="" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="psiLabel" runat="server" Text="" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="rightsidepanel" style="position: fixed; right: 0; display: inline-block;">
                    <div id="openrightpanel" class="rightpanel wrapper">
                        <img id="rightpanelicon" src="../Images/arrow-down-c.png" onclick="w3_openright()" />
                    </div>
                    <div id="closerightpanel" style="display: none;" class="rightpanel wrapper">
                        <img id="closerightpanelicon" src="../Images/arrow-down-c.png" style="-webkit-transform: rotate(180deg); /* chrome and other webkit browsers */
  -moz-transform: rotate(180deg); /* ff */
  -o-transform: rotate(180deg); /* opera */
  -ms-transform: rotate(180deg); /* ie9 */
  transform: rotate(180deg);"
                            onclick="w3_closeright()" />

                        <div style="position: inherit; display: none;" id="myRightSidenav">
                            <div id="notepad">
                                <textarea placeholder="Enter your notes here"></textarea>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
    </form>
</asp:Content>
