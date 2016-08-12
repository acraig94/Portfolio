package com.bit.alan.eventfinder;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.Toast;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.LatLng;
import com.yelp.clientlib.connection.YelpAPI;
import com.yelp.clientlib.connection.YelpAPIFactory;
import com.yelp.clientlib.entities.Business;
import com.yelp.clientlib.entities.SearchResponse;
import com.yelp.clientlib.entities.options.CoordinateOptions;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import retrofit2.Call;

/**
 * Created by Alan on 25/05/2016.
 */
public class RequestAPI
{
    private final static String consumer = "0K3iG-J8lyYCLP41oSuDCQ";
    private final static String consumerSecret = "yQvsgNIwP02yIZ1W3gYQmk48wT8";
    private final static String token = "I2B64SjyHHt3umUu9RA715uW638q0LmA";
    private final static String tokenSecret = "Rl-nyKw3qrLjb2zOmeB8dUVIlg0";
    private final static int ZOOMLEVEL = 13;

    private YelpAPI yelpAPI;
    private Activity parentActivity;

    public List<Business> getBusinesses() {
        return businesses;
    }
    private List<Business> businesses;
    private LatLng myLatLng;
    private String searchTerm;
    private MapUtils mu;
    private GoogleMap gMap;
    private int range;
    private int minStarRating;

    public RequestAPI(Activity parentActivity, LatLng myLatLng, MapUtils mu, GoogleMap gMap){ //TODO add SearchParams to the constructor for input
        this.parentActivity = parentActivity;
        this.myLatLng = myLatLng;
        //this.searchTerm = searchTerm;
        this.mu = mu;
        this.gMap = gMap;
        YelpAPIFactory apiFactory = new YelpAPIFactory(consumer, consumerSecret, token, tokenSecret);
        yelpAPI = apiFactory.createAPI();

        //MakeRequest();
    }

    // Quick Dirty way to implement filter dialog
    public void SetTerm(String s){
        searchTerm = s;
    }
    public void SetRange(int i){
        range = i;
    }
    public void SetMinStarRating(int r){
        minStarRating = r;
    }

    //Executes Async Task
    public void MakeRequest(){
        SearchParams input = new SearchParams(myLatLng.latitude, myLatLng.longitude, searchTerm, range); //TODO Get input for terms
        SearchAPI searchAPI = new SearchAPI();

        searchAPI.execute(input);
    }
    // Async task to search for all businesses near the users location relating to the search term
    public class SearchAPI extends AsyncTask<SearchParams, Void, List<Business>> {
        private ProgressDialog progress;

        @Override
        protected List<Business> doInBackground(SearchParams... params) {
            SearchParams p = params[0];
            Map<String, String> par = new HashMap<>();
            // location
            CoordinateOptions coordinate = CoordinateOptions.builder()
                    .latitude(p.getLat())
                    .longitude(p.getLng()).build();
            // params
            par.put("term", p.getTerm());
            par.put("radius_filter", Integer.toString(p.getRange()));
            Call<SearchResponse> call = yelpAPI.search(coordinate, par);
            ArrayList<Business> businessesList = new ArrayList<Business>();

            try {
                SearchResponse response = call.execute().body();
                businessesList = response.businesses();
            } catch (IOException e) { e.printStackTrace(); }

            for (int i = 0; i < businessesList.size();i++){
                Log.e("business", businessesList.get(i).name() + "\nID: " + businessesList.get(i).id() + "\nRating: " + businessesList.get(i).rating() + "\n Address: " + businessesList.get(i).location().address().get(0) + "\n Rating count: " + businessesList.get(i).reviewCount() + "\n phone #: " + businessesList.get(i).displayPhone() + "\n img url: " + businessesList.get(i).imageUrl() + "\n dis: " + businessesList.get(i).distance() + "\n lat lng: " + businessesList.get(i).location().coordinate().latitude() + ", " + businessesList.get(i).location().coordinate().longitude());
            }
            return businessesList;
        }
        // calls maputils addmarker method on each business
        protected void onPostExecute(List<Business> b){
            businesses = b;
            //Log.e("List size pre", "" + b.size() + "\n " + b.get(0).name());
            progress.dismiss();

            if (businesses != null) {
                for (int i = 0; i < businesses.size(); i++) {
                    if (businesses.get(i).rating().intValue() >= minStarRating){
                        mu.AddMarker(gMap, businesses.get(i));
                    }
                }
            }
            else
                Toast.makeText(parentActivity, "is null", Toast.LENGTH_SHORT).show();
            gMap.moveCamera(CameraUpdateFactory.newLatLng(myLatLng));
            gMap.moveCamera(CameraUpdateFactory.zoomTo(ZOOMLEVEL));

        }

        protected void onPreExecute(){
            progress = ProgressDialog.show(parentActivity,"Loading","Finding locations", true);
        }

    }

    public List<Business> GetBusinessList(){
        return businesses;
    }




}
