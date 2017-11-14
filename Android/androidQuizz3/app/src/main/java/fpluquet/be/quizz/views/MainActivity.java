package fpluquet.be.quizz.views;

import android.content.Intent;
import android.content.res.AssetManager;
import android.content.res.Resources;
import android.os.Environment;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.widget.Toast;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.ArrayList;

import javax.xml.datatype.Duration;

import fpluquet.be.quizz.R;
import fpluquet.be.quizz.models.QuestionModel;

import static android.widget.Toast.LENGTH_LONG;
import static android.widget.Toast.LENGTH_SHORT;

public class MainActivity extends AppCompatActivity {

    private static final int QUESTION_RESULT = 1;
    private ArrayList<QuestionModel> questions;
    private int currentQuestionIndex = -1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setQuestions();
        launchNextQuestion();
    }

    private void setQuestions() {
        questions = new ArrayList<>();

        // todo : au lieu de ces questions, lisez les questions depuis le fichier questions.txt dans le dossier raw des ressources
        // DONE

//        // add a first question
//        QuestionModel question = new QuestionModel();
//        question.setText("Quelle est la capitale de la Belgique ?");
//        question.addAnswer("Bruxelles");
//        question.addAnswer("Paris");
//        question.addAnswer("Montréal");
//        question.addAnswer("Djibouti");
//        questions.add(question);
//
//        // add a second question
//        QuestionModel question2 = new QuestionModel();
//        question2.setText("Le cours d'Android est :");
//        question2.addAnswer("On verra à l'examen");
//        question2.addAnswer("Simple");
//        question2.addAnswer("A l'aise");
//        question2.addAnswer("Quel cours d'Android ?");
//        questions.add(question2);
//


        try {
            Resources res = getResources();
            InputStream in_s = res.openRawResource(R.raw.questions);

            byte[] b = new byte[in_s.available()];
            in_s.read(b);
            String notreFichier = new String(b);

            String[] as = notreFichier.split("\r\n");

            int i =0;
            QuestionModel tmp = new QuestionModel();
            //Toast.makeText(this,"LENGTH => "+as.length,LENGTH_SHORT).show();
            for (int j = 0; j<as.length; j++){

                //Toast.makeText(this,"-"+as[j]+"-"+as[j].length(),LENGTH_SHORT).show();
                if ( i == 0 ){

                    tmp.setText(""+as[j]);
                    i++;

                } else if ( !as[j].isEmpty() ){

                    //Toast.makeText(this,"=> "+as[j],LENGTH_SHORT).show();
                    tmp.addAnswer(""+as[j]);

                }
                if ( j == as.length-1 || ( !as[j+1].isEmpty() && as[j].isEmpty() ) ){
                    //Toast.makeText(this,"["+j+"] ADD QUESTION : " + tmp.getText(),LENGTH_SHORT).show();
                    i = 0;
                    questions.add(tmp);
                    tmp = new QuestionModel();

                }
//                if ( !as[j+1].isEmpty() && as[j].isEmpty() ){
//                    Toast.makeText(this,"["+j+"]PUTAIN CA MARCHE " + tmp.getText(),LENGTH_SHORT).show();
//                }

            }

        } catch (Exception e) {
            Toast.makeText(this,e.toString(),LENGTH_LONG);
        }

        // initialize the current question index
        currentQuestionIndex = -1;
    }

    private void launchNextQuestion() {
        currentQuestionIndex ++;
        if(currentQuestionIndex >= questions.size()) {
            Toast.makeText(this, "Plus de questions...", Toast.LENGTH_SHORT).show();
            return;
        }
        QuestionModel question = questions.get(currentQuestionIndex);
        Intent intent = new Intent(this, QuestionActivity.class);
        intent.putExtra(QuestionActivity.QUESTION, question);

        startActivityForResult(intent, QUESTION_RESULT);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if(requestCode == QUESTION_RESULT && resultCode == RESULT_OK) {
            boolean isCorrect = data.getBooleanExtra(QuestionActivity.IS_CORRECT, false);
            String toShow;
            if(isCorrect){
                toShow = "Bravo !";
            } else {
                toShow = "Perdu :(";
            }
            Toast.makeText(this, toShow, Toast.LENGTH_SHORT).show();
            launchNextQuestion();
        }
    }


    // todo : retenez la question courante au cas où l'activité est relancée (rotation)
    // todo : ajoutez une fonctionnalité "continuer la dernière partie" (le numéro de la question courante est alors sauvé dans un fichier)
    // todo : ajoutez le score courant (à sauver dans le fichier)
    // todo : retenez dans la base de données toutes les parties (la date et le score obtenu)

}
