package com.damocorp.android.bapouproject;

import android.content.Context;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.view.View;
import android.widget.Button;
import android.widget.SeekBar;
import android.widget.TextView;
import android.widget.Toast;
import android.app.ProgressDialog;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.os.AsyncTask;
import android.widget.ToggleButton;

import java.io.IOException;
import java.sql.Time;
import java.util.Date;
import java.util.UUID;

public class TestActivity extends AppCompatActivity {

    Button btnDis;
    SeekBar brightness;
    String address;
    private ProgressDialog progress;
    BluetoothAdapter myBluetooth;
    BluetoothSocket btSocket;
    private boolean isBtConnected;
    static final UUID myUUID = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB");
    boolean isLedOn;
    Button btnOn;
    Button btnOff;
    Button btnHorloge;
    Button sendcolor;
    SeekBar Rouge;
    SeekBar Vert;
    SeekBar Bleu;
    int r,g,b;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_test);

//        ConnectBT test = new ConnectBT();

        myBluetooth = null;
        btSocket = null;
        isBtConnected = false;
        isLedOn = false;

        //receive the address of the bluetooth device
        Intent newint = getIntent();
        address = newint.getStringExtra("EXTRA_ADDRESS");

        //call the widgtes
        btnOn = findViewById(R.id.buttonOn);
        btnOff = findViewById(R.id.buttonOff);
        btnHorloge = findViewById(R.id.HorlogeTps);
        btnDis = findViewById(R.id.button4);
        Rouge = findViewById(R.id.Red);
        Vert = findViewById(R.id.Green);
        Bleu = findViewById(R.id.Blue);
        sendcolor = findViewById(R.id.SendColor);

        r = 0;
        g = 0;
        b = 0;

        sendcolor.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String toSend = "C"+r+"_"+g+"_"+b+"\n";

                if (btSocket != null && toSend!= "") {
                    //msg("Serial : OK "+toSend);
                    try {
                        btSocket.getOutputStream().write((""+toSend).toString().getBytes());
                        //msg("Serial : "+toSend);
                    } catch (IOException e) {
                        //msg("Error "+e.toString());
                    }
                } else {
                    //msg("Serial : PAS OK => |"+toSend);
                }

            }
        });

        Rouge.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            int resultat = 0;

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
//                msg("resultat : "+resultat);
                r = resultat;
                changeBoutonColor();
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }

            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                // TODO Auto-generated method stub
                resultat = progress;
            }

        });
        Vert.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            int resultat = 0;

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
//                msg("resultat : "+resultat);
                g = resultat;
                changeBoutonColor();
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }

            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                // TODO Auto-generated method stub
                resultat = progress;
            }

        });

        Bleu.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {

            int resultat = 0;

            @Override
            public void onStopTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
//                msg("resultat : "+resultat);
                b = resultat;
                changeBoutonColor();
            }

            @Override
            public void onStartTrackingTouch(SeekBar seekBar) {
                // TODO Auto-generated method stub
            }

            @Override
            public void onProgressChanged(SeekBar seekBar, int progress, boolean fromUser) {
                // TODO Auto-generated method stub
                resultat = progress;
            }

        });

        btnOn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ToggleLed("on");
            }
        });
        btnOff.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ToggleLed("off");
            }
        });
        btnHorloge.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SendHorlogeTps();
            }
        });


        btnDis.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Disconnect(); //close connection
            }
        });


        try {
            if (btSocket == null || !isBtConnected) {

                myBluetooth = BluetoothAdapter.getDefaultAdapter();//get the mobile bluetooth device
                BluetoothDevice dispositivo = myBluetooth.getRemoteDevice(address);//connects to the device's address and checks if it's available
                btSocket = dispositivo.createInsecureRfcommSocketToServiceRecord(myUUID);//create a RFCOMM (SPP) connection
                BluetoothAdapter.getDefaultAdapter().cancelDiscovery();
                btSocket.connect();//start connection
                isBtConnected = true;

            }
            Toast.makeText(this,"CONNECTION REUSSI",Toast.LENGTH_LONG);
        } catch (IOException e) {
            isBtConnected = false;
            Toast.makeText(this,"CONNECTION RATE DANS TON CUL HERCULE",Toast.LENGTH_LONG);
        }

    }

    private void changeBoutonColor(){

        Button buton = findViewById(R.id.SendColor);
        buton.setBackgroundColor(Color.rgb(r,g,b));

    }

        private void msg(String s) {
            Toast.makeText(getApplicationContext(), s, Toast.LENGTH_SHORT).show();
        }

        private void Disconnect() {
            if (btSocket != null) //If the btSocket is busy
            {
                try {
                    btSocket.close(); //close connection
                } catch (IOException e) {
                    msg("Error");
                }
            }
            finish(); //return to the first layout
        }

    private void ToggleLed(String etat) {

        String toSend = "";

        // si led non allumées + ordre d'allumage
        if ( etat == "on" ){
            // to Arduino => ALLUMAGE CONNARD
            toSend = "A\n";
        }

        // si led allumées + ordre d'extinction
        if ( etat == "off" ){
            // to Arduino => STOP CONSOMMER BORDEL
            toSend = "S\n";
        }

        if (btSocket != null && toSend!= "") {
            //msg("Serial : OK "+toSend);
            try {
                btSocket.getOutputStream().write((""+toSend).toString().getBytes());
                //msg("Serial : "+toSend);
            } catch (IOException e) {
                //msg("Error "+e.toString());
            }
        } else {
            //msg("Serial : PAS OK => |"+toSend);
        }


    }

    private void SendHorlogeTps(){

        String toSend = "";

        int hours = new Time(System.currentTimeMillis()).getHours();
        int minutes = new Time(System.currentTimeMillis()).getMinutes();
        toSend = "T"+hours+minutes+"\n";

        msg("Serial : => |"+toSend);

        if (btSocket != null && toSend!= "") {
            try {
                btSocket.getOutputStream().write((""+toSend).toString().getBytes());
            } catch (IOException e) {
            }
        }

    }




        private class ConnectBT extends AsyncTask<Void, Void, Void>  // UI thread
        {
            private boolean ConnectSuccess = true; //if it's here, it's almost connected



            @Override
            protected void onPreExecute() {
                progress = ProgressDialog.show(TestActivity.this, "Connecting...", "Please wait!!!");  //show a progress dialog
            }

            @Override
            protected Void doInBackground(Void... devices) //while the progress dialog is shown, the connection is done in background
            {
                try {
                    if (btSocket == null || !isBtConnected) {
                        myBluetooth = BluetoothAdapter.getDefaultAdapter();//get the mobile bluetooth device
                        BluetoothDevice dispositivo = myBluetooth.getRemoteDevice(address);//connects to the device's address and checks if it's available
                        btSocket = dispositivo.createInsecureRfcommSocketToServiceRecord(myUUID);//create a RFCOMM (SPP) connection
                        BluetoothAdapter.getDefaultAdapter().cancelDiscovery();
                        btSocket.connect();//start connection
                    }
                } catch (IOException e) {
                    ConnectSuccess = false;//if the try failed, you can check the exception here
                }

                return null;
            }

            @Override
            protected void onPostExecute(Void result) //after the doInBackground, it checks if everything went fine
            {
                super.onPostExecute(result);

                if (!ConnectSuccess) {
                    msg("Connection Failed. Is it a SPP Bluetooth? Try again.");
                    finish();
                } else {
                    msg("Connected.");
                    isBtConnected = true;
                }
                progress.dismiss();
            }
        }

}

