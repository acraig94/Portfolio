package com.bit.alan.eventfinder;

import android.content.Context;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.support.v4.graphics.drawable.DrawableCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.RatingBar;
import android.widget.TextView;

import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.model.Marker;
import com.yelp.clientlib.entities.Business;

import io.techery.properratingbar.ProperRatingBar;

/**
 * Created by Alan on 25/05/2016.
 */
public class CustomInfoWindow implements GoogleMap.InfoWindowAdapter {
    private LayoutInflater inflater;
    private Business b;

    public CustomInfoWindow(LayoutInflater inflater, Business b){
        this.inflater = inflater;
        this.b = b;
    }

    @Override
    public View getInfoWindow(Marker marker) {
        View v = inflater.inflate(R.layout.custom_info_window, null);
        TextView tvName = (TextView) v.findViewById(R.id.tv_name);
        ProperRatingBar properRatingBar = (ProperRatingBar) v.findViewById(R.id.RatingBar);
        TextView tvRating = (TextView) v.findViewById(R.id.tv_rating);
        //TextView tvAddress = (TextView) v.findViewById(R.id.tv_Address);
        tvName.setText(b.name());
        String rating;
        if (b.reviewCount() != 0){
            //rating = b.rating().toString();
            //RatingBar rb = (RatingBar) v.findViewById(R.id.cwRatingBar);

            properRatingBar.setRating((b.rating().intValue()));
            tvRating.setVisibility(v.GONE);

        }
        else {
            tvRating.setText("No rating");
            properRatingBar.setVisibility(v.GONE);
        }
        //tvAddress.setText("Address: " + b.location().address().get(0));
        return v;
    }

    @Override
    public View getInfoContents(Marker marker) {
        //LayoutInflater inflater = (LayoutInflater) context.getSystemService( Context.LAYOUT_INFLATER_SERVICE );
        View v = inflater.inflate(R.layout.custom_info_window_layout, null);
        TextView tvName = (TextView) v.findViewById(R.id.tv_Name);
        TextView tvRating = (TextView) v.findViewById(R.id.tv_Rating);
        TextView tvAddress = (TextView) v.findViewById(R.id.tv_Address);
        tvName.setText(b.name());
        tvRating.setText("Rating: " + b.rating());
        tvAddress.setText("Address: " + b.location().address().get(0));
        return v;
    }
}
