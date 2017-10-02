package com.damocorop.app01;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.EditText;
import android.widget.TextView;

import org.w3c.dom.Text;

public class Activity01 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_01);

        EditText nom = (EditText) findViewById(R.id.txtNom);
        TextView resultat = (TextView) findViewById(R.id.txtResultat);
        resultat.setText( nom.getText() );
    }

}
