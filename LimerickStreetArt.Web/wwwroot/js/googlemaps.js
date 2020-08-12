function initMap()
{
    let mapDivElement = document.getElementById('map');
    let mapCenterLatlng = { lat: -25.363, lng: 131.044 };
    let mapOptions = { zoom: 4, center: mapCenterLatlng };

    let map = new google.maps.Map(mapDivElement, mapOptions);

    // Create the initial InfoWindow.
    var infoWindow = new google.maps.InfoWindow(
        { content: 'Click the map to get Lat/Lng!', position: mapCenterLatlng });
    infoWindow.open(map);

    // Configure the click listener.
    map.addListener('click', function (mapsMouseEvent)
    {
        // Close the current InfoWindow.
        infoWindow.close();

        // Create a new InfoWindow.
        infoWindow = new google.maps.InfoWindow({ position: mapsMouseEvent.latLng });
        infoWindow.setContent(mapsMouseEvent.latLng.toString());
        infoWindow.open(map);
    });
}