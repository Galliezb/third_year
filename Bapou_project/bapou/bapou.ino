#include <Adafruit_NeoPixel.h>
#include <SoftwareSerial.h>

// change les pin RX TX sur  10-11
SoftwareSerial mySerial(10, 11);

// variable globale
bool isDoublePointDisplay = false;
int testDigit1 = 0;
int testDigit2 = 0;
int testDigit3 = 0;
int testDigit4 = 0;
unsigned long NbrBalle = 0;
String inputString = "";
bool allumageLed = false;
unsigned long maxBalleParTps = millis();
unsigned long deuxpointseconde = millis();
short unsigned int compteurDeSeconde = 0;
short unsigned int r = 223;
short unsigned int g = 223;
short unsigned int b = 223;


// modèle de base
int chiffre[][25] = {
  {1,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1},
  {1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,0,0,0,0,0,0},
  {0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0},
  {1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0},
  {1,1,1,1,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,1,1,1,1},
  {1,1,1,1,1,1,1,0,0,0,0,1,1,1,0,0,0,0,1,1,1,1,1,1,1},
  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1},
  {1,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0},
  {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
  {1,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
};
int display_horloge_digit[] = {8,4,3,2};
// 0-> unite
// 4-> dizaine de millier
int display_compte_digit[] = {0,0,0,0,0};


// Parameter 1 = number of pixels in strip
// Parameter 2 = pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)

//102 LED HORLOGE => PIN 6
Adafruit_NeoPixel HORLOGE = Adafruit_NeoPixel(102, 6, NEO_GRB + NEO_KHZ800);
// 125 LED COMPTEUR => PIN 7
Adafruit_NeoPixel COMPTEUR = Adafruit_NeoPixel(125, 7, NEO_GRB + NEO_KHZ800);

void setup() {

  // mets la pin 4 a l'état haut, si le switch est enfoncé
  // on va a la masse et on détecte un passage de balle
  pinMode(4,INPUT_PULLUP);

  // initialize serial:
  Serial.begin(9600);
  mySerial.begin(9600);
  // reserve 200 bytes for the inputString:
  inputString.reserve(30);
  
  HORLOGE.begin();
  HORLOGE.show(); // Initialise toute les led à 'off'
  HORLOGE.setBrightness(20);
  COMPTEUR.begin();
  COMPTEUR.setBrightness(20);
  COMPTEUR.show();
}



void loop() {  

  // détection des balles
  IncrementeNbrBalle();

  // si les leds doivent être allumé :
  if ( allumageLed ){
    
    UpdateHorloge();
    UpdateCompteurDeBalle();
    
  }
  Serial.println("Debut Reception : "+inputString);
  inputString = "";
  ReceptionSerial();

}

void IncrementeNbrBalle(){

  // empeche la détection de balle a plus d'une par seconde
  if ( maxBalleParTps+1000 < millis() ){

    // si le switch est enfoncé
    if ( digitalRead(4) == LOW ){
  
      NbrBalle++;
      maxBalleParTps=millis();
      
    }
    
  }
  
}

void UpdateCompteurDeBalle(){

  long toTravail = NbrBalle;
  
  display_compte_digit[4] = floor(toTravail/10000);
  toTravail -= display_compte_digit[4]*10000;
  display_compte_digit[3] = floor(toTravail/1000);
  toTravail -= display_compte_digit[3]*1000;
  display_compte_digit[2] = floor(toTravail/100);
  toTravail -= display_compte_digit[2]*100;
  display_compte_digit[1] = floor(toTravail/10);
  toTravail -= display_compte_digit[1]*10;
  display_compte_digit[0] = toTravail;
  
  // on parcours les 4 digits
  for ( int leDigitATraiter = 0; leDigitATraiter < 5; leDigitATraiter++ ){

      bool chiffreEteind = false;
      // si > 0 alors on affiche, sinon on éteind tout le digit
      if ( leDigitATraiter!=0 && NbrBalle < pow(10,leDigitATraiter) ){
        chiffreEteind = true;
      }      

      for(int i =0; i < 25; i++ ) {
        
        int chiffre_a_afficher = display_compte_digit[leDigitATraiter];
        int ledToDisplay = leDigitATraiter*25+i;

        if ( chiffre[chiffre_a_afficher][i] != 0 && !chiffreEteind ) {
          COMPTEUR.setPixelColor(ledToDisplay, r, g, b);
        } else {
          COMPTEUR.setPixelColor(ledToDisplay, 0, 0, 0);
        }

      }

  }
  
  COMPTEUR.show(); // on affiche
  
}

void UpdateHorloge(){

  // on parcours les 4 digits
  for ( int leDigitATraiter = 0; leDigitATraiter < 4; leDigitATraiter++ ){

      
      
      for(int i =0; i < 25; i++ ) {
        
        int chiffre_a_afficher = display_horloge_digit[leDigitATraiter];
        int ledToDisplay = leDigitATraiter*25+i;

        if ( chiffre[chiffre_a_afficher][i] != 0 ) {
          HORLOGE.setPixelColor(ledToDisplay, r, g, b);
        } else {
          HORLOGE.setPixelColor(ledToDisplay, 0, 0, 0);
        }

      }

  }

  // gestion des : de lhorloge 
  if ( isDoublePointDisplay == true ){
    
    HORLOGE.setPixelColor(100, 0, 0, 0);
    HORLOGE.setPixelColor(101, 0, 0, 0);
    
    if ( deuxpointseconde+1000 < millis() ){
       isDoublePointDisplay = false;
       deuxpointseconde = millis();
       updateTimeForHorloge();
    }
    
  } else {
    HORLOGE.setPixelColor(100, r, g, b);
    HORLOGE.setPixelColor(101, r, g, b);

    if ( deuxpointseconde+1000 < millis() ){
       isDoublePointDisplay = true;
       deuxpointseconde = millis();
       updateTimeForHorloge();
    }
    
  }
  
  HORLOGE.show(); // on affiche
  
}

void updateTimeForHorloge(){

  //display_horloge_digit[0-4]
  compteurDeSeconde++;

  if ( compteurDeSeconde == 60) {
    
    compteurDeSeconde=0;

    // si min == 9 cas particulier
    if( display_horloge_digit[0] == 9 ){

      // minute = 0
      display_horloge_digit[0] = 0;
      
      // si dizaine de min > 5 cas particulier
      if( display_horloge_digit[1] == 5){

        display_horloge_digit[1] = 0;

        // ATTENTION > 3 et > 9 pour les heures
        if( display_horloge_digit[3] == 2 && display_horloge_digit[2] == 3 ){

          display_horloge_digit[3] = 0;
          display_horloge_digit[2] = 0;

        } else if ( display_horloge_digit[3] < 2 && display_horloge_digit[2] == 9 ) {

          display_horloge_digit[3]++;
          display_horloge_digit[2] = 0;

        // on ajoute une heure
        } else {
          display_horloge_digit[2]++;
        }

      } else {
         display_horloge_digit[1]++;
      }
      
    } else {
      
      display_horloge_digit[0]++;
      
    }
    
  }
  
}

void ReceptionSerial(){

  if ( mySerial.available() > 0 ){
  //if ( true ){
  
      // lecture des datas
      inputString = "";
      int x = 0;
      while (mySerial.available()) {
        // Recuperation d'un byte
        char inChar = (char)mySerial.read();
        // Ajout du character
        
        if ( inChar == '\r' ) {
          break;
        } else if (inChar == '\n'){
          break;
        }else {
          inputString += inChar;
          delay(10);
        }
        // on empeche d'aller trop loin si ça merde
        x++;
        if ( x == 30 ) { break; } 
      }  
      // on effectue l'action selon le code reçu
      // A = Allumage des leds
      if ( inputString == "A" ){
        allumageLed = true;     
        Serial.print("Allumage Led : "+inputString);
      // S = Eteindre les leds
      } else if ( inputString == "S" ){
        allumageLed = false;
        Serial.println("Eteindre Led : "+inputString);
      } else if ( inputString.charAt(0) == 'T' ){
        // mets à jours l'horloge
        if ( inputString.length() == 5 ){
          
          int to3 = returnMoiCePutainDeChiffre( inputString.charAt(1) );
          int to2 = returnMoiCePutainDeChiffre( inputString.charAt(2) );
          int to1 = returnMoiCePutainDeChiffre( inputString.charAt(3) );
          int to0 = returnMoiCePutainDeChiffre( inputString.charAt(4) );
          
          display_horloge_digit[3]= to3;
          display_horloge_digit[2]= to2;
          display_horloge_digit[1]= to1;
          display_horloge_digit[0]= to0;
          
        }

      } else if ( inputString.charAt(0) == 'C' ){
        
        short unsigned int cpt = 0;
        
        // Ex : C1_1_1 C1_19_19 C255_45_0
        String tmp = "";
        for ( int i=1; i< inputString.length(); i++ ){

          if ( inputString[i] != '_' ){
            
            tmp+=inputString[i];
            
          } else if ( inputString[i] == '_' || i == inputString.length() ) {
            
            long l = tmp.toInt();

            
            if ( cpt == 0 ){
              r = int(l);
              cpt++;
            } else if ( cpt == 1 ){
              g = int(l);
              cpt++;
            } else if ( cpt == 2 ){
              b = int(l);
            }
            
            tmp="";
          }

          
        }


      }
  }
}

int returnMoiCePutainDeChiffre(char t){

  if ( t == '0' ){
    return 0;
  } else if ( t == '1' ){
    return 1;
  } else if ( t == '2' ){
    return 2;
  } else if ( t == '3' ){
    return 3;
  } else if ( t == '4' ){
    return 4;
  } else if ( t == '5' ){
    return 5;
  } else if ( t == '6' ){
    return 6;
  } else if ( t == '7' ){
    return 7;
  } else if ( t == '8' ){
    return 8;
  } else if ( t == '9' ){
    return 9;
  } else {
    return -1;
  }
}

