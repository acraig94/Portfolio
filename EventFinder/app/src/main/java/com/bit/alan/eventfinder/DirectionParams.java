package com.bit.alan.eventfinder;

import com.google.android.gms.maps.model.LatLng;

/**
 * Created by Alan on 30/05/2016.
 */
// Used to pass into Directions
public class DirectionParams {

    public LatLng getOrigin() {
        return origin;
    }

    public LatLng getDestination() {
        return destination;
    }

    private LatLng origin;
    private LatLng destination;
    //private String transportationMode; //TODO Allow user to specify transport mode
    public DirectionParams(LatLng origin, LatLng destination){
        this.origin = origin;
        this.destination = destination;
    }

}
