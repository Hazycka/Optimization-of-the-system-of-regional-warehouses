var map = L.map('map', {
    center: [59.9358, 30.3133],
    zoom: 11
});

var defaultTileLayer = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '© OpenStreetMap contributors'
});

defaultTileLayer.addTo(map);

var warehouse_icon = L.icon({
    iconUrl: 'img/red.png',
    iconSize: [20, 29],
    iconAnchor: [10, 29],
    popupAnchor: [0, -29]
});

var deliveryPoint_icon = L.icon({
    iconUrl: 'img/blue.png',
    iconSize: [20, 29],
    iconAnchor: [10, 29],
    popupAnchor: [0, -29]
});

map.on('click', function (e) {
    var latLng = e.latlng;
    L.popup()
        .setContent(`<p>${latLng.toString()}</p>`)
        .setLatLng(latLng)
        .openOn(map);
});

function SetRouteMap()
{
    map.remove();

    map = L.map('routeMap', {
        center: [59.9358, 30.3133],
        zoom: 11
    });

    defaultTileLayer.addTo(map);
}

function SetWarehouse(name, lat, lon, cost)
{
    L.marker(L.latLng(lat, lon), { icon: warehouse_icon }).addTo(map).bindPopup(`РЦ "${name}" (lat: ${lat}, lon: ${lon}), Cost: ${cost}`);
}

function SetDeliveryPoint(name, lat, lon, frequency)
{
    L.marker(L.latLng(lat, lon), { icon: deliveryPoint_icon }).addTo(map).bindPopup(`Точка доставки "${name}" (lat: ${lat}, lon: ${lon}), Частота: ${frequency}`);
}

function SetRoutedDeliveryPoint(name, lat, lon, distance, frequency) {
    L.marker(L.latLng(lat, lon), { icon: deliveryPoint_icon }).addTo(map).bindPopup(`Точка доставки "${name}" (lat: ${lat}, lon: ${lon}), Расстояние до РЦ: ${distance}, Частота: ${frequency}`);
}

function SetRoute(warehouseLat, warehouseLon, deliveryPointLat, deliveryPointLon)
{
    var startPoint = L.latLng(warehouseLat, warehouseLon)
    var endPoint = L.latLng(deliveryPointLat, deliveryPointLon)

    L.Routing.control({
        waypoints: [
            startPoint,
            endPoint
        ],
        routeWhileDragging: false,
        createMarker: function () { return false; },
        show: false
    }).addTo(map);
}

function RefreshMap() {
    map.remove();

    map = L.map('map', {
        center: [59.9358, 30.3133],
        zoom: 11
    });

    defaultTileLayer.addTo(map);

    map.on('click', function (e) {
        var latLng = e.latlng;
        L.popup()
            .setContent(`<p>${latLng.toString()}</p>`)
            .setLatLng(latLng)
            .openOn(map);
    });
}



//L.marker(L.latLng(59.9749, 30.3999), { icon: warehouse_icon }).addTo(map).bindPopup("59.9749, 30.3999");
//L.marker(L.latLng(59.8490, 30.2412), { icon: warehouse_icon }).addTo(map).bindPopup("59.8490, 30.2412");

//L.Routing.control({
//    waypoints: [
//        L.latLng(59.9749, 30.3999),
//        L.latLng(59.9430, 30.4898)
//    ],
//    routeWhileDragging: false,
//    createMarker: function () { return false; },
//    show: false
//}).addTo(map);

//L.Routing.control({
//    waypoints: [
//        L.latLng(59.9749, 30.3999),
//        L.latLng(59.9818, 30.2776)
//    ],
//    routeWhileDragging: false,
//    createMarker: function () { return false; },
//    show: false
//}).addTo(map);

//L.Routing.control({
//    waypoints: [
//        L.latLng(59.8490, 30.2412),
//        L.latLng(59.8510, 30.0929)
//    ],
//    routeWhileDragging: false,
//    createMarker: function () { return false; },
//    show: false
//}).addTo(map);

//L.Routing.control({
//    waypoints: [
//        L.latLng(59.8490, 30.2412),
//        L.latLng(59.8403, 30.4129)
//    ],
//    routeWhileDragging: false,
//    createMarker: function () { return false; },
//    show: false
//}).addTo(map);




////// default map layer
////let map = L.map('map', {
////    layers: MQ.mapLayer(),
////    center: [59.939098, 30.315868],
////    zoom: 12
////});

////function runDirection(start, end) {

////    // recreating new map layer after removal
////    map = L.map('map', {
////        layers: MQ.mapLayer(),
////        center: [59.939098, 30.315868],
////        zoom: 12
////    });

////    var dir = MQ.routing.directions();

////    dir.route({
////        locations: [
////            start,
////            end
////        ]
////    });


////    CustomRouteLayer = MQ.Routing.RouteLayer.extend({
////        createStartMarker: (location) => {
////            var custom_icon;
////            var marker;

////            custom_icon = L.icon({
////                iconUrl: 'img/red.png',
////                iconSize: [20, 29],
////                iconAnchor: [10, 29],
////                popupAnchor: [0, -29]
////            });

////            marker = L.marker(location.latLng, { icon: custom_icon }).addTo(map);

////            return marker;
////        },

////        createEndMarker: (location) => {
////            var custom_icon;
////            var marker;

////            custom_icon = L.icon({
////                iconUrl: 'img/blue.png',
////                iconSize: [20, 29],
////                iconAnchor: [10, 29],
////                popupAnchor: [0, -29]
////            });

////            marker = L.marker(location.latLng, { icon: custom_icon }).addTo(map);

////            return marker;
////        }
////    });

////    map.addLayer(new CustomRouteLayer({
////        directions: dir,
////        fitBounds: true
////    }));
////}


////// function that runs when form submitted
////function submitForm(event) {
////    event.preventDefault();

////    // delete current map layer
////    map.remove();

////    // getting form data
////    start = document.getElementById("start").value;
////    end = document.getElementById("destination").value;

////    // run directions function
////    runDirection(start, end);

////    // reset form
////    document.getElementById("form").reset();
////}


////const form = document.getElementById('form');

////form.addEventListener('submit', submitForm);