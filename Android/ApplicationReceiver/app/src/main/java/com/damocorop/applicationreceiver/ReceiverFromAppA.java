package com.damocorop.applicationreceiver;

import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.widget.Toast;

/**
 * Created by super on 18/10/2017.
 */

public class ReceiverFromAppA extends BroadcastReceiver {

    @Override
    public void onReceive(Context context,Intent intent) {
        Log.d("moi","onReceive OK");
        String messageRecu = intent.getStringExtra("monTxt");
        Toast.makeText(context,"Receiver : "+messageRecu,Toast.LENGTH_LONG).show();

        Toast.makeText(context,"Receiver : "+intent.getAction(),Toast.LENGTH_LONG).show();
    }


}
