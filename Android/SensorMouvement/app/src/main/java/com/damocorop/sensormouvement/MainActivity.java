package com.damocorop.sensormouvement;

import android.os.Debug;
import android.support.constraint.ConstraintLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.Button;

import java.io.Console;
import java.util.Random;
import java.util.TimerTask;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ChangePosition();

    }

    public void ChangePosition(){

        ConstraintLayout monC = findViewById( R.id.monConstraintLayout );

        Button monBouton = findViewById( R.id.btToMove );
        Log.d("RANDOM",""+(new Random().nextFloat())+" * "+(monC.getHeight()) +" - "+monBouton.getMaxHeight() );
        monBouton.setX(new Random().nextFloat()*(monC.getHeight()-monBouton.getHeight()));
        monBouton.setY(new Random().nextFloat()*(monC.getWidth()-monBouton.getWidth()));

        //ChangePosition();

    }

}
