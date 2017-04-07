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
            document.getElementById("rightpanel").style.marginRight = (document.getElementById("closerightpanel").offsetWidth)-50 + "px";
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
        //var btn = document.getElementById("ViewDetails");

        var btn1 = document.getElementById("CreateIncident");

        // Get the <span> element that closes the modal
        var span = document.getElementsByClassName("close")[0];
        var span1 = document.getElementsByClassName("close1")[0];

        // When the user clicks the button, open the modal
        /*btn.onclick = function () {
            modal.style.display = "block";
            return false;
        }*/

        btn1.onclick = function () {
            if (document.getElementById('infowindow-content').children["CreateIncident"].textContent == "Create Incident") {
                createModal.style.display = "block";
            }
            else if (document.getElementById('infowindow-content').children["CreateIncident"].textContent == "View Incident") {
                //GridData.in
                var table = document.getElementById("MainContent_GridData");
                for (var i = 1; i < table.rows.length; i++) {
                    if (state == table.rows[i].cells[0].innerHTML) {
                        console.log("correct");
                        document.getElementById("MainContent_GridData").rows[i].cells[5].children[0].click()
                    }
                }
            }
               console.log("MAP_ID: " + state);

                console.log("TableID: "+table.rows[2].cells[0].innerHTML);
                //console.log(document.getElementById("MainContent_GridData").children[0].);
            
            document.getElementById('LatInfo').value = window.defaultPlaceGResult.latitude;
            document.getElementById('LngInfo').value = window.defaultPlaceGResult.longitude;
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

    function displayModal() {
        document.getElementById('myModal').style.display = "block";
    }

    function closeModal() {
        document.getElementById('CreateIncidentDialogBox').style.display = "none";
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

    google.maps.event.addDomListener(window, 'load', init);

    function init() {
        CMSEmergencySystem.Map.Initialize("map", "pac-input", "infowindow-content");
        CMSEmergencySystem.Map.AddDefaultPlaceListener(onPlaceSelected);
        CMSEmergencySystem.Map.AddPlaceSelectedListener(onPlaceSelected);
        CMSEmergencySystem.Map.AddDefaultPlaceListener(cacheDefaultPlaceGResult);
        document.getElementById('LatInfo').value = CMSEmergencySystem.Map._InfoWindowContent.children["lng"].textContent;
        document.getElementById('LngInfo').value = CMSEmergencySystem.Map._InfoWindowContent.children["lng"].textContent;
        console.log(document.getElementById('LatInfo').value);
        //Load Dengue KML
        dengueLayer = CMSEmergencySystem.Map.LoadDengue();

        //NEA Marker Function
        <%
        for(var i = 0; i < weather2hrArray.GetLength(0); i++)
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
            <h2>View Incident Report</h2>
        </div>
        <div class="modal-body">
                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                 
                <table class="CurrentIncident">
                    <tr>
                        <th>Date/Time of Report:</th>
                        <td><asp:Label ID="DateTimeDisplay" runat="server" Text=""></asp:Label></td>
                        <th colspan="3"></th>
                    </tr>
                    <tr>
                        <th>Type of Incident:</th>
                        <td><asp:Label ID="incidentType" runat="server" Text=""></asp:Label></td>
                        <th>Incident ID:</th>
                        <td><asp:Label ID="IncidentID" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Reporting Person:</th>
                        <td><asp:Label ID="reporterName" runat="server" Text=""></asp:Label></td>
                        <th>Contact No:</th>
                        <td><asp:Label ID="contactNumber" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Location:</th>
                        <td><asp:Label ID="Location" runat="server" Text=""></asp:Label></td>
                        <th>Postal Code:</th>
                        <td><asp:Label ID="postalCode" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Main Dispatch:</th>
                        <td><asp:Label ID="mainDispatch" runat="server" Text=""></asp:Label></td>
                        <th>Assist Type:</th>
                        <td><asp:TextBox id="supportType" TextMode="multiline" Columns="30" Rows="5" runat="server" ReadOnly="True" /></td>
                    </tr>
                    <tr>
                        <th>Description:</th>
                        <td colspan="3"><asp:Label ID="incidentDesc" runat="server" Text=""></asp:Label> </td>
                    </tr>

                    <tr>
                        <th>Status Log :</th>
                        <td><asp:TextBox id="statusLog" TextMode="multiline" Columns="30" Rows="5" runat="server" ReadOnly="True" Width="452px" /> </td>
                    </tr>
 
            <tr><th>Update Status</th>
            <td><asp:DropDownList ID="statusUpdate" runat="server">
            <asp:ListItem Text="Unresolved" Value="Unresolved" />
            <asp:ListItem Text="Pending" Value="Pending" />
            <asp:ListItem Text="Resolved" Value="Resolved" />
        </asp:DropDownList></td>
                </tr>
         
                    <tr>
                        <th>Add Status:</th>
                        <td>
                            <asp:TextBox ID="Status" runat="server"></asp:TextBox></td>
                        <td><asp:Button ID="Button1" runat="server" Text="Update" OnClick="UpdateStatusOnClick" /></td>
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
            <h2>Create Incident Report</h2>
        </div>
        <div class="modal-body">

            <asp:UpdatePanel ID="UpdateCreate" runat="server">              
                <ContentTemplate>
                <asp:HiddenField ID="LatInfo" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="LngInfo" runat="server" ClientIDMode="Static" />
                <table class="CreateIncident" width="100%">
                    <tr>
                        <th>Type of Incident:</th>
                        <td colspan="3">
                            <asp:DropDownList ID="typeOfIncidentDDL" runat="server">
                                <asp:ListItem Text="Fire Outbreak" Value="Fire Outbreak" />
                                <asp:ListItem Text="Riot Outbreak" Value="Riot Outbreak" />
                                <asp:ListItem Text="Car Accident" Value="Car Accident" />
                                <asp:ListItem Text="Terrorist" Value="Terrorist" />
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

     
        </div>
                            
                </ContentTemplate>
                </asp:UpdatePanel>   
        <div class="modal-footer">
        </div>
    </div>
</div>
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
            <div style="position: inherit;display: none;height:100%;" id="mySidenav">

                <div id="livefeed">
                    <div style="background-color: #3b5998;height: auto;">
                            <img src="Images/facebookicon.png" style="height: 40px;width: auto;"/>
                            FACEBOOK
                        </div>
                        <div class="LiveFeedCSS">
                            <div id="fbLiveFeed" class="feed" runat="server">

                            </div>
                            <%--<div class="fb-page" data-href="http://www.facebook.com/CMSXiaoYaoPai" data-tabs="timeline" data-small-header="true" data-adapt-container-width="true" data-hide-cover="false" data-show-facepile="true"><blockquote cite="http://www.facebook.com/CMSXiaoYaoPai" class="fb-xfbml-parse-ignore"><a href="http://www.facebook.com/CMSXiaoYaoPai">Crisis Management System Xiao Yao Pai</a></blockquote></div>
                            <script src="//www.powr.io/powr.js" external-type="html"></script> 
 <div class="powr-social-feed" id="f140960d_1491094268"></div>--%>
                            <!--<asp:Button ID="facebookBtn" Text="Login to Facebook" onClick="myFacebookLogin()">Login to Facebook!</asp:Button>
                            <asp:Button ID="Button2" Text="Post to Facebook" onClick="myFacebookPost()">Post to Facebook!</asp:Button>-->

                        </div>
                    <div style="background-color: #1da1f2;height: auto;">
                            <img src="Images/twittericon.png" style="height: 40px;width: auto;"/>
                            TWITTER
                        </div>
                    <div class="LiveFeedCSS">
                        <div id="twitterLiveFeed" class="feed" runat="server">
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="rightpanel">
        <input id="pac-input" class="controls" type="text" placeholder="Search Box" style="width: 300px;">
        <div id="map">
        </div>
        
        <table>
        <tr>
        <%--<td> Fire Outbreaks : </td>
        <td>
            <input type="checkbox" id= "showFire"name="showfire" onclick="CheckedChanged();" checked/>
            Riot Outbreaks:
            <input type="checkbox" id= "showRiot"name="riot" onclick="CheckedChanged();" checked/>
            Car Accident:
            <input type="checkbox" id= "showCarAccident"name="caraccident" onclick="CheckedChanged();" checked/>
            Terrorist:
            <input type="checkbox" id= "showTerrorist"name="terrorist" onclick="CheckedChanged();" checked/>
        </td>--%>
            <td>
                Weather: 
                <input type="checkbox" id="weatherCheckBox" name="weatherCheckBox" onclick="CheckedChanged();"/>
                Dengue:
                <input type="checkbox" id="dengueCheckBox" name="dengueCheckBox" onclick="toggleDengue();"/>
            </td>
        <td><asp:Label ID="showFireDisplay" runat="server"></asp:Label></td>
        </tr> 
        </table>

        <div id="infowindow-content">
      <span id="place-name"  class="title"></span><br>
      Place ID <span id="place-id"></span><br>
      <a id="CreateIncident">Create Incident</a><br>
      <span id="lat">Latitude: </span><br>
      <span id="lng">Longitude: </span><br>
      <span id="place-address"></span>
    </div>
        <div id="legend">
            <h4>Legend</h4>
            <p><img src = "/Icons/caraccident.png" style="width: 50px;height:40px;padding-right: 10px"/>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src = "/Icons/Fire.png"style="width: 50px;height:40px;padding-right: 10px"/>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src = "/Icons/riot.png"style="width: 50px;height:40px;padding-right: 10px"/>
                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<img src = "/Icons/terrorist.png"style="width: 50px;height:40px;padding-right: 10px"/>
            </p>
            <p> Accident &nbsp&nbsp&nbsp&nbsp&nbsp Fire &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Riot  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp Terrorist</p>
            <p>&nbsp&nbsp&nbsp&nbsp&nbsp<input type="checkbox" id= "showCarAccident"name="caraccident" onclick="CheckedChanged();" checked/>
&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<input type="checkbox" id= "showFire"name="showfire" onclick="CheckedChanged();" checked/>
             &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<input type="checkbox" id= "showRiot"name="riot" onclick="CheckedChanged();" checked/>
&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<input type="checkbox" id= "showTerrorist"name="terrorist" onclick="CheckedChanged();" checked/></p>
        </div>
        <div id="Incidents" style="margin: 10px;">
            <div id="tabs">
                <ul class="nav nav-tabs">
                    <li><a onclick="tab1();">Current Incidents</a></li>
                    <li><a onclick="tab2();">Resolved Incidents</a></li>
                </ul>
                <!--<h3>Search : </h3>-->
                <div style="padding:5px;border:1px solid #dfd7ca;">
                <asp:TextBox ID="searchResult" runat="server" CssClass="form-control"></asp:TextBox>
                <asp:Button ID="sendQuery" runat="server" Text="Search" OnClick="sendQuery_Click" CssClass="btn btn-primary"/>
                <asp:Button ID="clearQuery" runat="server" Text="Clear" OnClick="clearQuery_Click" CssClass="btn btn-primary"/>
                    </div>
                    <div id="tabs-1" style="width: 100%; height: 883px;">
                         <!--<h2>Current Incident</h2> -->
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">              
                <ContentTemplate>

                <div class="gridViewTable">
                    <asp:GridView ID="GridData" runat="server" AutoGenerateColumns="False" onrowcommand="ViewPendingIncident_RowCommand" 
                         Width="100%" CssClass="table table-striped table-hover"> 
           
            <Columns>
                <asp:BoundField DataField="IncidentId" HeaderText="Id" />
                <asp:BoundField DataField="dateTime" HeaderText="Date/Time" />
                <asp:BoundField DataField="IncidentType" HeaderText = "IncidentType" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="VI" Text="View Incident" CommandName="Select" runat="server" return ="false" CssClass="btn btn-default"/>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="deleteRow" Text="Delete" CommandName="Delete" runat="server" CssClass="btn btn-default"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                    </asp:GridView>
                    </div>
                    </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>


                <div id="tabs-2" style="display:none;width: 100%;">   
                <!--<h2>Resolved Incidents</h2> -->        
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">              
                <ContentTemplate>
                    <asp:GridView ID="GridData2" runat="server" AutoGenerateColumns="False" onrowcommand="ViewResolvedIncident_RowCommand"
                         Width="100%" HeaderStyle-BackColor="#98e698" HeaderStyle-ForeColor="Black" RowStyle-BackColor="White" 
                        AlternatingRowStyle-BackColor="White" RowStyle-ForeColor="#3A3A3A"> 
            <Columns>
                <asp:BoundField DataField="IncidentId" HeaderText="Id" />
                <asp:BoundField DataField="dateTime" HeaderText="Date/Time" />
                <asp:BoundField DataField="IncidentType" HeaderText = "IncidentType" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:BoundField DataField="Location" HeaderText="Location" />
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="VI" ClientIDMode="Static" Text="View Incident" CommandName="Select" runat="server" return ="false"/> 
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="deleteRow" Text="Delete" CommandName="Delete" runat="server" /> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
                    </asp:GridView>
                 </ContentTemplate>
                 </asp:UpdatePanel>
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
</form>



</asp:Content>
