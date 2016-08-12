package com.bit.alan.eventfinder;

import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.LatLng;

import java.io.Serializable;

/**
 * Created by Alan on 31/05/2016.
 */

// Object which is passed into a business fragment
public class BusinessFragmentDataPack implements Serializable {

    private LatLng myLatLng;

    public MapUtils getMapUtils() {
        return mapUtils;
    }

    public LatLng getMyLatLng() {
        return myLatLng;
    }

    public GoogleMap getgMap() {
        return gMap;
    }

    private GoogleMap gMap;
    private MapUtils mapUtils;

    public BusinessFragmentDataPack(LatLng myLatLng, GoogleMap gMap, MapUtils mapUtils){
        this.gMap = gMap;
        this.mapUtils = mapUtils;
        this.myLatLng = myLatLng;
    }



}
