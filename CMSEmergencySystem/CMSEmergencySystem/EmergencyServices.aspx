<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmergencyServices.aspx.cs" Inherits="CMSEmergencySystem.EmergencyServices" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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

        function toggleBomb() {
            for (var i = 0; i < pushBombShelter.length; i++) {
                //console.log(listOfBombShelter.length);
                if (document.getElementById("bombShelterCheckBox").checked == true)
                    pushBombShelter[i].setVisible(true);
                else
                    pushBombShelter[i].setVisible(false);
            }
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
            //var btn = document.getElementById("ViewDetails");
            var btn1 = document.getElementById("CreateIncident");

            // Get the <span> element that closes the modal
            var span = document.getElementsByClassName("close")[0];
            var span1 = document.getElementsByClassName("close1")[0];

            btn1.onclick = function () {

                if (document.getElementById('infowindow-content').children["CreateIncident"].textContent == "View Incident") {
                    //GridData.in
                    var table = document.getElementById("MainContent_GridData");
                    for (var i = 1; i < table.rows.length; i++) {
                        if (state == table.rows[i].cells[0].innerHTML) {
                            document.getElementById("MainContent_GridData").rows[i].cells[5].children[0].click()
                        }
                    }
                }
                return false;
            }

            // When the user clicks on <span> (x), close the modal
            span.onclick = function () {
                modal.style.display = "none";
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

        function displayModal() {
            document.getElementById('myModal').style.display = "block";
        }


    </script>
    <script>
        function ViewIncidentButtonTest() {
            var modal = document.getElementById('myModal');

            // Get the <span> element that closes the modal
            var spanTest = document.getElementsByClassName("close")[0];
            //var span1 = document.getElementsByClassName("close1")[0];

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

    <script>
        function userValid() {
            var ReportPerson, ContactNo, Postal, Description;
 
            ReportPerson = document.getElementById("MainContent_reportPersonTextBox").value;
            ContactNo = document.getElementById("MainContent_contactNoTextBox").value;
            Postal = document.getElementById("MainContent_postalCodeTextBox").value;
            Description = document.getElementById("MainContent_descriptionTextBox").value;
            //emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id
 
            if (ReportPerson == '' && ContactNo == '' && Postal == '' && Description == '') {
                alert("Enter All Fields");
                return false;
            }

            if (ReportPerson == '') {
                alert("Please Enter Reporter Name");
                return false;
            }
            if (ContactNo == '') {
                alert("Please Enter Contact No");
                return false;
            }
            if (Postal == '')
            {
                alert("Please Enter Postal");
                return false;
            }
            if (Description == '')
            {
                alert("Please Enter Description");
                return false;
            }
            return true;
        }

    </script>

    <title>CMS Emergency System</title>
    <!--implement JQuery tab panel-->
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <!--End implement JQuery tab panel-->
    <!--Api Key-->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBTdSKDpeyLxGmVqZSkMzxyX2X0341nbFQ&libraries=places&extension=.js"></script>
    <script src="/Scripts/map.js" type="text/javascript"></script>
   
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
                    if (incident.Status == "Unresolved") {
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

            },
            error: function () { }
        });

        $.ajax("/BombShelterServlet.aspx", {
            success: function (data) {
                listOfBombShelter = JSON.parse(data);
                for (var i = 0; i < listOfBombShelter.length; i++) {
                    var BombShelter = listOfBombShelter[i];
                    BombShelter.latitude = BombShelter.Latitude;
                    BombShelter.longitude = BombShelter.Longitude;
                    var marker = CMSEmergencySystem.Map.BombShelterAddMarker(new google.maps.LatLng(BombShelter.Latitude, BombShelter.Longitude));
                    marker.setVisible(false);
                    pushBombShelter.push(marker);
                }
            },
            error: function () { }
        });

        }

    function cacheDefaultPlaceGResult(marker, geocodeResult) {
        window.defaultPlaceGResult = geocodeResult;
    }

    function onPlaceSelected(marker, geocodeResult) {
        // Whenever a place is selected this listener will be called
        // Retrieve the place from marker._Place
        if (fire.indexOf(marker) != -1 || caraccident.indexOf(marker) != -1 || riot.indexOf(marker) != -1 || terrorist.indexOf(marker) != -1) {
            document.getElementById('infowindow-content').children["CreateIncident"].textContent = "View Incident";
        }
        else {
            document.getElementById('infowindow-content').children["CreateIncident"].textContent = "";
        }

    }

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
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                                    <th>Add Status Log : </th>
                                    <td>
                                        <asp:TextBox ID="Status" runat="server"></asp:TextBox></td>
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
        <asp:HiddenField ID="LatInfo" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="LngInfo" runat="server" ClientIDMode="Static" />

        
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
                                    <asp:UpdatePanel ID="UpdatePanelFBLiveFeed" class="feed" runat="server">
                                        <ContentTemplate>
                                            <div id="fbLiveFeed" runat="server"></div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="background-color: #1da1f2; height: auto;">
                                    <img src="Images/twittericon.png" style="height: 40px; width: auto;" />
                                    TWITTER
                                </div>
                                <div class="LiveFeedCSS">
                                    <asp:UpdatePanel ID="UpdatePanel4" class="feed" runat="server">
                                        <ContentTemplate>
                                            <div id="twitterLiveFeed" runat="server"></div>
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
                        <span id="place-name" class="title"></span><br />
                        <span id="place-id"></span>
                        <span id="lat"></span><br />
                        <span id="lng"></span><br />
                        <span id="place-address"></span><br />
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
                            
                            <asp:UpdatePanel ID="searchQuery" runat="server">  
                                <ContentTemplate>
                            <div style="padding: 5px; border: 1px solid #dfd7ca;">
                                <asp:TextBox ID="searchResult" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="sendQuery" runat="server" Text="Search" OnClick="sendQuery_Click" CssClass="btn btn-primary" />
                                <asp:Button ID="clearQuery" runat="server" Text="Clear" OnClick="clearQuery_Click" CssClass="btn btn-primary" />
                            </div>
                                   </ContentTemplate>
                                </asp:UpdatePanel>
                                  

                            <div id="tabs-1" style="width: 100%;">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
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
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
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
