package com.bit.alan.eventfinder;

import android.Manifest;
import android.content.Context;
import android.content.pm.PackageManager;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationManager;
import android.support.v4.app.ActivityCompat;
import android.util.Log;
import android.view.View;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.android.gms.maps.model.MarkerOptions;
import com.google.android.gms.maps.model.Polyline;
import com.google.android.gms.maps.model.PolylineOptions;
import com.yelp.clientlib.entities.Business;

import java.util.ArrayList;

/**
 * Created by Alan on 25/05/2016.
 */

// Utilities class with methods for map related tasks
public class MapUtils {
    private final static int ZOOMLEVEL = 10;

    //private GoogleMap gMap;
    //public GoogleMap getgMap() { return gMap; }
    private Context context;
    public MapUtils(Context context){
        this.context = context;
    }
    // Adds a single marker to the map
    public void AddMarker(GoogleMap gMap, Business business){
        String name = business.name();
        double rating = business.rating();
        double nRatings = business.reviewCount();
        String snip;
        //if (nRatings != 0){
            //snip = "Rating: " + business.rating();
            snip = business.id();
        //}
        //else { snip = "Rating: N/A"; }
        double lat = business.location().coordinate().latitude();
        double lng = business.location().coordinate().longitude();
        LatLng latlng = new LatLng(lat, lng);
        gMap.addMarker(new MarkerOptions()
                        .position(latlng)
                        .title(name)
                        .snippet(snip)
        );
        //gMap.setInfoWindowAdapter(new CustomInfoWindow(context, business));
    }
    // Draws a polyline onto the map given a list of waypoints
    public void DrawRoute(GoogleMap gMap, ArrayList<LatLng> wayPoints){
        PolylineOptions routeOptions = new PolylineOptions();
        for (int i = 0; i < wayPoints.size(); i++){
            routeOptions.add(new LatLng(wayPoints.get(i).latitude, wayPoints.get(i).longitude));
        }
        gMap.addPolyline(routeOptions);
    }
    // gets the users current location
    public LatLng GetLocation() {
        LocationManager lm = (LocationManager) context.getSystemService(Context.LOCATION_SERVICE);
        Criteria criteria = new Criteria();
        String providerName = lm.getBestProvider(criteria, false);
        if (ActivityCompat.checkSelfPermission(context, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(context, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            return new LatLng(0,0);
        }
        Location currentLocation = lm.getLastKnownLocation(providerName);
        double lat = currentLocation.getLatitude();
        double lng = currentLocation.getLongitude();
        return new LatLng(lat, lng);
    }



}
