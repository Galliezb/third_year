package com.damocorop.app01;

import android.content.ActivityNotFoundException;
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
                Toast.makeText(Activity01.this,"test",Toast.LENGTH_SHORT).show();
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

        Button boutonAppB = (Button) findViewById(R.id.boutonAppB);
        boutonAppB.setOnClickListener(new View.OnClickListener(){

            @Override
            public void onClick(View v){

                try {

                    // créer l'intent pour envoyer vers appB
                    Intent versAppB = new Intent("com.damocorop.app01.versAppB");
                    // ajoute les données dans l'intent
                    versAppB.putExtra("monTxt", ((TextView) findViewById(R.id.txtConfirmationName)).getText().toString());

                    //Envoyer
                    startActivity(versAppB);
                } catch (ActivityNotFoundException e){
                    Toast.makeText(Activity01.this,"APPB NOT FOUND BORDEL DE MERDE", Toast.LENGTH_SHORT).show();
                }
            }

        });

        Button boutonReceiver = (Button) findViewById(R.id.boutonReceiver);
        boutonReceiver.setOnClickListener(new View.OnClickListener(){

            @Override
            public void onClick(View v){
                Toast.makeText(Activity01.this,"envoye vers receiver", Toast.LENGTH_SHORT).show();
                try {

                    // créer l'intent pour envoyer vers appB

                    Intent versReceiver = new Intent("com.damocorop.app01.VERS_RECEIVER");
                    // ajoute les données dans l'intent
                    versReceiver.putExtra("monTxt", ((TextView) findViewById(R.id.txtConfirmationName)).getText().toString());

                    //Envoyer en Broadcast
                    sendBroadcast(versReceiver);

                // si personne ne capte, on préviens via le catch exception
                } catch (ActivityNotFoundException e){
                    Toast.makeText(Activity01.this,"PERSONNE N'ECOUTE BORDEL DE MERDE", Toast.LENGTH_SHORT).show();
                }
            }

        });

    }

    // remplacé par le code au dessus pour l'attacher à l'évènement d'un bouton
    //public void onClickOnButton(View v){

    //    Toast.makeText(this,"clicage de butonnage",Toast.LENGTH_SHORT);

    //}

}
