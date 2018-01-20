package com.damocorop.applicationforsaving;

//import android.icu.util.Calendar;
import android.os.Debug;
import android.os.PersistableBundle;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;

import java.util.Calendar;

public class MainActivity extends AppCompatActivity {

    public static final String LAST_TIME_1 = "com.damocorp.applicationforsaving.lastPressedTime";
    private long lastPressedTime,lastPressedTime2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // on vérifie qu'il est pas null ( genre pas de save lors du premier lancement
        if ( savedInstanceState != null){

            lastPressedTime = savedInstanceState.getLong(LAST_TIME_1);
            ((Button)findViewById(R.id.bt1)).setText("" + lastPressedTime);

        }

    }

    // cette fonction sur deux boutons va donner le timestamp directemet sur le bouton
    // grace à la vue
    public void onBTnClick(View view){
        lastPressedTime = Calendar.getInstance().getTimeInMillis();
        ((Button)view ).setText(""+lastPressedTime);
    }

    // quand il change d'état ( exemple portrait / paysage )
    // des informations sont parfois perdu car l'application est tué et relancé
    // cette surcharge de méthode va permettre de faire la sauvegarde des elements que l'on veut
    // le super va a la fin, si on sauvegarde une data, le super ne le fera pas
    // si on fait l'inverse, la sauvegarde sera double :(
    @Override
    protected void onSaveInstanceState(Bundle outState) {

        // ce qui est sauvegardé est justement reçu en paramètre dans le onCreate
        outState.putLong("nomDeLaVariableQuOnRecuperera",lastPressedTime);
        super.onSaveInstanceState(outState);

    }

}
