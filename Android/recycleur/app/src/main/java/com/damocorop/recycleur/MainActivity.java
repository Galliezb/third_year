package com.damocorop.recycleur;

import android.support.constraint.ConstraintLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    /*

    square.github.io pour des assets sympas
    on prend picasso ( gère la cache et l'affichage image )
    retrofit permet de gérer une client HTTP
    voncerter-gson pour le traitement JSON

    1=> square.github.io/retrofit/

     */

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ConstraintLayout cl = findViewById(R.id.test);
        TextView tv = findViewById(R.id.txt);

        tv.setText( "width : "+cl.getWidth() );
    }
}
