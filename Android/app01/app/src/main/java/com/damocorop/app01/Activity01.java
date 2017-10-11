package com.damocorop.app01;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

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
                // petit popup
                Toast.makeText(Activity01.this,"test",Toast.LENGTH_SHORT);
                // appeler une nouvelle activity
                Intent newIntent = new Intent(Activity01.this,Activity02.class);
                // startActivity est déclaré ans AppCompatActivity
                //Activity01.this si nécessaire

                // récupérer le nom + l'envoyer en paramètre
                String txtToSend = ((TextView) findViewById(R.id.txtConfirmationName)).getText().toString();
                newIntent.putExtra("name", txtToSend);
                startActivity(newIntent);

            }
        });

    }

    // remplacé par le code au dessus pour l'attacher à l'évènement d'un bouton
    //public void onClickOnButton(View v){

    //    Toast.makeText(this,"clicage de butonnage",Toast.LENGTH_SHORT);

    //}

}
