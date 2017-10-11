package com.damocorop.app01;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class Activity02 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_02);

        // récupérer la valeur
        String nomRecupere = getIntent().getExtras().getString("name");
        // réinjection  dans le txtEdit
        ((EditText)findViewById(R.id.txtConfirmationName)).setText(nomRecupere);


        // ajouter l'evenemtn de création d'intent sur le bouton confirmer
        Button btConfirmation = (Button) findViewById(R.id.btConfirm);
        // Ajout le code voulu en surchargeant
        btConfirmation.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View v){

                Intent newIntent = new Intent(Activity02.this,Bonjour.class);
                newIntent.putExtra("name", ((EditText)findViewById(R.id.txtConfirmationName)).getText().toString() );
                startActivity(newIntent);
            }
        });

    }


}
