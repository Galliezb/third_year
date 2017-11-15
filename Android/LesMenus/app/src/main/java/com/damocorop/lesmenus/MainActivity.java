package com.damocorop.lesmenus;

import android.app.TimePickerDialog;
import android.content.DialogInterface;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.TimePicker;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public boolean


    // gère la création des menus, les 3 points situé en haut et à droite
    // on crér le menu dans les ressource, on l'ajoute sur ce onCreate
    // et on l'utilise comme toutes les autres interfaces avec les id etc...
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater monMenu = getMenuInflater();
        monMenu.inflate(R.menu.menu1, menu);
        return super.onCreateOptionsMenu(menu);
    }
// evenementiel sur le menu
    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch  (item.getItemId()){
            case R.id.idItem1 :

                // permet de gérer des timepicker dialog
//                new TimePickerDialog(this,new TimePickerDialog().ontime
                // ProgressDialog
                // permet de mettre l'icon de loading habituelle automatiquement
                // avec le builder, on a accès à des tonnes d'options comme d'hab

                // thread en java
                // new thread(new Runnable(){@override run() .... Thread.sleep(2000) }
                // try catch InterruptedException e
                // setIndeterminate( false ) + progressDialog.setMax(100) pour donner l'avancerment
                // setProgress(0) par défaut ça avance pas
                // setprogressstyle nécessaie sinon on voit rien
                // le final permet de conserver la référence et on peut donc y accéder même dans le thread.

                // en passant par le builder, on va créer une instance en s'aidant d'un Builder
                new AlertDialog.Builder(this)
                        .setMessage("Message de l'alertDialog") // déini le message
                        .setTitle("Titre AlertDialog")  // défini le titre
                        .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialogInterface, int which) {

                                Toast.makeText(getBaseContext(),"evenement sur le sous menu",Toast.LENGTH_SHORT);
                            }
                        }) // rien de particulier sur l'evenement si on met null
                        .setCancelable(false) // tant qu'on clic pas sur OK, le menu disparait pas
                        .create()
                        .show();
                Toast.makeText(this,"clic menu 1",Toast.LENGTH_SHORT).show();
                return true;
            case R.id.idItem2 :
                Toast.makeText(this,"clic menu 1",Toast.LENGTH_SHORT).show();
                return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
