package com.bit.alan.eventfinder;

import com.google.android.gms.maps.GoogleMap;

import java.io.Serializable;

/**
 * Created by Alan on 10/06/2016.
 */
public class FilterDataPack implements Serializable {

    private GoogleMap gmap;

    public RequestAPI getRequestAPI() {
        return requestAPI;
    }

    public GoogleMap getGmap() {
        return gmap;
    }

    private RequestAPI requestAPI;

    public FilterDataPack(GoogleMap gmap, RequestAPI requestAPI){
        this.gmap = gmap;
        this.requestAPI = requestAPI;
    }
}
