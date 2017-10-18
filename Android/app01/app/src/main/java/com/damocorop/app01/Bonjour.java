package com.damocorop.app01;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;

public class Bonjour extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bonjour);

        String nomRecu = getIntent().getExtras().getString("name");
        String txtToDisplay = "Bonjour "+nomRecu+", c'était pas si dûr hein ?<br />AS à planté 18 fois pour générer ce truc de merde.";
        ((TextView)findViewById(R.id.txtViewBonjour)).setText(txtToDisplay);

    }


}
