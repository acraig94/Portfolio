package com.bit.alan.eventfinder;

/**
 * Created by Alan on 25/05/2016.
 */
public class SearchParams
{
    private double lat;
    private double lng;
    private String term;
    private int range;

    public SearchParams(double lat, double lng, String term, int range){
        this.lat = lat;
        this.lng = lng;
        this.term = term;
        this.range = range;
    }

    public double getLat() {
        return lat;
    }

    public double getLng() { return lng; }

    public String getTerm() {
        return term;
    }

    public int getRange() { return range; }

}
