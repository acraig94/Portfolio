package com.bit.alan.eventfinder;


import android.app.DialogFragment;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.content.res.Resources;
import android.support.v4.graphics.drawable.DrawableCompat;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.RatingBar;

import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.model.LatLng;
import com.yelp.clientlib.entities.Business;

import java.util.ArrayList;

import io.techery.properratingbar.ProperRatingBar;


/**
 * A simple {@link Fragment} subclass.
 */
public class BusinessFragment extends DialogFragment {

    private final static int ZOOMLEVEL = 13;

    private Business b;
    private BusinessFragmentDataPack data;
    private Context context;
    private View v;
    private ListView lv_details;
    private boolean reviews_enable;

    public BusinessFragment(){}

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        v = inflater.inflate(R.layout.fragment_business, container, false);
        // Get business
        Bundle bundle = getArguments();
        data = (BusinessFragmentDataPack) bundle.getSerializable("dataPack");
        b = (Business) bundle.getSerializable("currentBusiness");
        getDialog().setTitle(b.name());
        lv_details = (ListView) v.findViewById(R.id.lv_businessDialog);
        Button btnDirections = (Button) v.findViewById(R.id.btn_Directions);
        Button btnClose = (Button) v.findViewById(R.id.btn_Close);

        btnDirections.setOnClickListener(new DirectionsOnClickHandler());
        btnClose.setOnClickListener(new CloseHandler());

        LoadList();
        return v;
    }
    // Loads the listview
    public void LoadList(){
        ArrayList<String> details = CreateDetails();
        ArrayAdapter<String> testAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, details);
        lv_details.setAdapter(testAdapter);
    }
    // Creates string arraylist with all the businesses details
    public ArrayList<String> CreateDetails(){
        ArrayList<String> details = new ArrayList<String>();
        if (b.reviewCount() != 0) {
            //details.add("Average rating of " + b.rating());
            ProperRatingBar properRatingBar = (ProperRatingBar) v.findViewById(R.id.RatingBarFD);
            properRatingBar.setRating(b.rating().intValue());
        }
        else {
            details.add("No reviews available");
        }
        // Check if address is available
        if (b.location().displayAddress() != null) {
            details.add(b.location().displayAddress().get(0));
        }
        else{
            details.add("Address unavailable");
        }
        // Check if phone number is available
        if(b.displayPhone() != null) {
            details.add(b.displayPhone());
        }
        else {
            details.add("Phone number unavailable");
        }


        return details;
    }
    // When the directions button is clicked directions will be showed on the map and fragment dialog will close
    public class DirectionsOnClickHandler implements View.OnClickListener{

        @Override
        public void onClick(View v) {
            data.getgMap().clear();
            data.getMapUtils().AddMarker(data.getgMap(),b);
            DirectionParams directionParams = new DirectionParams(new LatLng(data.getMyLatLng().latitude,data.getMyLatLng().longitude), new LatLng(b.location().coordinate().latitude(),b.location().coordinate().longitude()));
            Directions directions = new Directions(directionParams, data.getMapUtils(), data.getgMap());
            data.getgMap().moveCamera(CameraUpdateFactory.newLatLng(data.getMapUtils().GetLocation()));
            data.getgMap().moveCamera(CameraUpdateFactory.zoomTo(ZOOMLEVEL));
            dismiss();

        }
    }
    // Handler to close the fragment dialog
    public class CloseHandler implements View.OnClickListener{

        @Override
        public void onClick(View v) {
            dismiss();
        }
    }



}
