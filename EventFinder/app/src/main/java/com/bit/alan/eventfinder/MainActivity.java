package com.bit.alan.eventfinder;

import android.Manifest;
import android.app.Activity;
import android.app.FragmentManager;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.OnMapReadyCallback;
import com.google.android.gms.maps.SupportMapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.google.android.gms.maps.model.Marker;
import com.google.maps.android.PolyUtil;
import com.yelp.clientlib.entities.Business;

import java.util.ArrayList;
import java.util.List;


public class MainActivity extends AppCompatActivity {

    private final static int ZOOMLEVEL = 13;

    private SupportMapFragment mapFragment;
    private GoogleMap gMap;

    private Spinner spinner;
    private List<Business> businesses;
    private Business nBusiness;
    private RequestAPI requestAPI;
    private MapUtils mapUtils;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mapUtils = new MapUtils(this);

        mapFragment = (SupportMapFragment) getSupportFragmentManager().findFragmentById(R.id.map);
        mapFragment.getMapAsync(new MapCallBack());
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu){
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.toolbar, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item){
        Log.e("Filters", "Filtering");
        FragmentManager fm = getFragmentManager();
        FilterFragment dialog = new FilterFragment();

        requestAPI = new RequestAPI(MainActivity.this, mapUtils.GetLocation(), mapUtils, gMap);
        Bundle bundle = new Bundle();
        FilterDataPack data = new FilterDataPack(gMap, requestAPI);
        bundle.putSerializable("dataPack", data);
        dialog.setArguments(bundle);
        dialog.show(fm, "Filter");
        return true;
    }

    public class MapCallBack implements OnMapReadyCallback,
            GoogleMap.OnInfoWindowClickListener,
            GoogleMap.OnMarkerClickListener {

        // Creates the map and on creation goes to users position. Sets listeners for events
        @Override
        public void onMapReady(GoogleMap googleMap) { //TODO Put location management into own method or class
            gMap = googleMap;
            gMap.moveCamera(CameraUpdateFactory.newLatLng(mapUtils.GetLocation()));
            gMap.moveCamera(CameraUpdateFactory.zoomTo(ZOOMLEVEL));
            gMap.setOnInfoWindowClickListener(this);
            gMap.setOnMarkerClickListener(this);
            if (ActivityCompat.checkSelfPermission(MainActivity.this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(MainActivity.this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {

                return;
            }
            gMap.setMyLocationEnabled(true);
            gMap.getUiSettings().setZoomControlsEnabled(true);
            gMap.getUiSettings().setMapToolbarEnabled(false);
        }
        // when an info window is clicked a business dialog fragment will be created
        @Override
        public void onInfoWindowClick(Marker marker) {
            FragmentManager fm = getFragmentManager();
            BusinessFragment dialog = new BusinessFragment();
            Bundle bundle = new Bundle();
            BusinessFragmentDataPack data = new BusinessFragmentDataPack(mapUtils.GetLocation(), gMap, mapUtils);
            bundle.putSerializable("currentBusiness", nBusiness);
            bundle.putSerializable("dataPack", data);
            dialog.setArguments(bundle);
            Log.e("BFrag", nBusiness.name());
            dialog.show(fm, "Business");
        }
        // when a marker is clicked a custom info window will appear with the associated businesses information
        @Override
        public boolean onMarkerClick(Marker marker) {
            businesses = requestAPI.getBusinesses();
            String id = marker.getSnippet();
            for (int i = 0; i < businesses.size(); i++) {
                if (businesses.get(i).id().equals(id)) {
                    nBusiness = businesses.get(i);
                }
            }
            if (nBusiness.id().equals(id)) {
                gMap.setInfoWindowAdapter(new CustomInfoWindow(getLayoutInflater(), nBusiness));
                marker.showInfoWindow();
            }
            return false;
        }
    }



}
