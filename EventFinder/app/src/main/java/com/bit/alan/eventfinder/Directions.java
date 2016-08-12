package com.bit.alan.eventfinder;

import android.os.AsyncTask;
import android.util.Log;
import android.widget.Toast;

import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.model.LatLng;
import com.google.maps.android.PolyUtil;
import com.yelp.clientlib.entities.Business;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by Alan on 30/05/2016.
 */
public class Directions {
    private DirectionParams directionParams;
    private ArrayList<LatLng> wayPoints;
    private MapUtils mu;
    private GoogleMap gMap;

    public Directions(DirectionParams directionParams, MapUtils mu, GoogleMap gMap){
        this.directionParams = directionParams;
        this.mu = mu;
        this.gMap = gMap;
        MakeRequest();
    }
    // Executes the Async task
    public void MakeRequest(){
        FindDirections findDirections = new FindDirections();
        findDirections.execute(directionParams);
    }
    // Async Tack to find directions from users current location to their destination
    public class FindDirections extends AsyncTask<DirectionParams, Void, String>{

        @Override
        protected String doInBackground(DirectionParams... params) {
            DirectionParams dp = params[0];

            String JSONString = null;

            try {
                String urlString = "https://maps.googleapis.com/maps/api/directions/json?" +
                        "origin=" + dp.getOrigin().latitude + "," + dp.getOrigin().longitude + "&" +
                        "destination=" + dp.getDestination().latitude + "," + dp.getDestination().longitude + "&" +
                        "mode=driving&" +
                        "key=" + "AIzaSyC-mbzU2xtuMBspXinzgqwM8_NtCIeEDbI";
                //Log.e("urlString", urlString);
                URL urlObject = new URL(urlString);
                HttpURLConnection connection = (HttpURLConnection) urlObject.openConnection();
                connection.connect();
                int responseCode = connection.getResponseCode();
                if (responseCode == 200) {
                    InputStream is = connection.getInputStream();
                    InputStreamReader reader = new InputStreamReader(is);
                    BufferedReader br = new BufferedReader(reader);
                    String responseStr;
                    StringBuilder strBuilder = new StringBuilder();
                    while ((responseStr = br.readLine()) != null) {
                        strBuilder = strBuilder.append(responseStr);
                    }
                    JSONString = strBuilder.toString();
                }
            }catch (Exception e){e.printStackTrace();};

            return JSONString;
        }
        // Takes json object, gets encoded string of points, decodes, and draws to the map
        protected void onPostExecute(String s){
            String encodedPoints = "";
            try {
                JSONObject jsonData = new JSONObject(s);
                JSONArray routes = jsonData.getJSONArray("routes");
                JSONObject route = routes.getJSONObject(0);
                JSONObject polyline = route.getJSONObject("overview_polyline");
                encodedPoints = polyline.getString("points");

            } catch (JSONException e) {
                e.printStackTrace();
            }
            Log.e("polyline", encodedPoints);
            wayPoints = (ArrayList<LatLng>) PolyUtil.decode(encodedPoints);
            mu.DrawRoute(gMap, wayPoints);
        }
    }




}
