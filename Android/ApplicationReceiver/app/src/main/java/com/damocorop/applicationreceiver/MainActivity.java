package com.damocorop.applicationreceiver;

import android.content.BroadcastReceiver;
import android.content.Intent;
import android.content.IntentFilter;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        AnswerToAppA();

    }

    @Override
    protected void onResume() {
        super.onResume();
        registerReceiver(new ReceiverFromAppA(),
                new IntentFilter("com.damocorop.app01.VERS_RECEIVER"));

    }

    public void AnswerToAppA(){

        Intent monIntent = getIntent();
        String monTxt = monIntent.getStringExtra("monTxt");

        // popup()
        Toast.makeText(MainActivity.this,"callIntent appB txt recu => "+monTxt,Toast.LENGTH_SHORT).show();

    }

}
