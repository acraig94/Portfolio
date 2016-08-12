package com.bit.alan.eventfinder;


import android.app.Dialog;
import android.app.DialogFragment;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.RatingBar;
import android.widget.SeekBar;
import android.widget.Spinner;
import android.widget.TextView;

import com.google.android.gms.maps.GoogleMap;

import java.util.Arrays;
import java.util.List;

import io.techery.properratingbar.ProperRatingBar;


/**
 * A simple {@link Fragment} subclass.
 */
public class FilterFragment extends DialogFragment {

    private Spinner spinner;
    private SeekBar seekBar;
    private TextView tv_range;
    private GoogleMap gMap;
    private RequestAPI requestAPI;
    private ProperRatingBar ratingBar;

    public FilterFragment() {}

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View v = inflater.inflate(R.layout.fragment_filter, container, false);
        spinner = (Spinner) v.findViewById(R.id.spinner_term);
        ArrayAdapter<CharSequence> adapter = ArrayAdapter.createFromResource(getActivity().getApplicationContext(), R.array.categories_array, R.layout.custom_spinner);
        adapter.setDropDownViewResource(R.layout.custom_spinner_dropdown);
        spinner.setAdapter(adapter);

        Bundle bundle = getArguments();
        FilterDataPack data = (FilterDataPack) bundle.getSerializable("dataPack");
        gMap = data.getGmap();
        requestAPI = data.getRequestAPI();

        seekBar = (SeekBar) v.findViewById(R.id.seekBar);
        seekBar.setProgress(seekBar.getMax() / 2);
        seekBar.setOnSeekBarChangeListener(new SeekBarHandler());

        tv_range = (TextView) v.findViewById(R.id.tv_Range);
        tv_range.setText(Integer.toString(seekBar.getProgress()));

        ratingBar = (ProperRatingBar) v.findViewById(R.id.RatingBarFilter);

        Button btn_Search = (Button) v.findViewById(R.id.button_Search);
        btn_Search.setOnClickListener(new SearchHandler());

        return v;
    }

    public class SearchHandler implements View.OnClickListener{

        @Override
        public void onClick(View v) {
            gMap.clear();
            String searchTerm = spinner.getSelectedItem().toString();
            requestAPI.SetTerm(searchTerm);
            requestAPI.SetRange(seekBar.getProgress());
            requestAPI.SetMinStarRating(ratingBar.getRating());
            requestAPI.MakeRequest();
            dismiss();
        }
    }



    public class SeekBarHandler implements SeekBar.OnSeekBarChangeListener{

        @Override
        public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
            tv_range.setText(Integer.toString(seekBar.getProgress()));
        }

        @Override
        public void onStartTrackingTouch(SeekBar seekBar) {

        }

        @Override
        public void onStopTrackingTouch(SeekBar seekBar) {

        }
    }
}
