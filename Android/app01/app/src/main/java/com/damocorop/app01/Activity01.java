package com.damocorop.app01;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.w3c.dom.Text;

public class Activity01 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.start);

        //EditText nom = (EditText) findViewById(R.id.txtNom);
        //TextView resultat = (TextView) findViewById(R.id.txtResultat);
        //resultat.setText( nom.getText() );

        // attacher une fonction à un évènement ( même style que javascript )
        Button bouton5 = (Button) findViewById(R.id.btStartEnvoyer);
        bouton5.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){
                Toast.makeText(MainActivity.this,"test",Toast.LENGTH_SHORT);
                // appeler une nouvelle activity
                Intent intent = new Intent(MainActivity.this,MainActivity.class);
                // startActivity est déclaré ans AppCompatActivity
                //MainActivity.this si nécessaire
                startArctivity(intent);
            }
        });

    }

    // remplacé par le code au dessus pour l'attacher à l'évènement d'un bouton
    //public void onClickOnButton(View v){

    //    Toast.makeText(this,"clicage de butonnage",Toast.LENGTH_SHORT);

    //}

}
