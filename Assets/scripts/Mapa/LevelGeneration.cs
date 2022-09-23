using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; // index 0 --> LR, index 1 --> LRB, index 2 --> LRT, index 3 --> LRBT
    public int[] direcciones;
    public int[] direcciones2;
    public int i=0;
    public int i2=0;
    public int direction;
    public int direction2;
    public int directionPos;
    public bool posi;
    public float moveAmount;
    public float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;
    public float minX;
    public int Cantidad;
    public int numHabit=10;
    private int moveCounter;
    public float maxX;
    public float maxY;
    public float minY;
    private bool stopGeneration;
    private bool stopGeneration2;
    private bool despDif;
    private Vector2 posmove;
    public LayerMask room;
    public int dire;
   public int puertaAntes;
    public bool ocupado=false;
  

    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
   
        direction= Random.Range(1,9);
       
        direcciones = new int [11];
      direcciones [i]=direction;
    i++;
                if(direction==1 || direction==2){
                      transform.position = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                 if(direction==3 || direction==4){
                      transform.position = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction==5 || direction==6){
                    transform.position = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(direction==7 || direction==8){
                    transform.position = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
    }


    private void Update() 
    {
       
       if(Cantidad==0 && posi==true)
       {
        posi=false;
       }
       else if(Cantidad!=0 && posi==false)
       {
        posi=true;
       }
       
       
        if(timeBtwRoom <=0 && stopGeneration == false)
        {
            if(Cantidad!=0)
            {
                Posibilidad();
                timeBtwRoom= startTimeBtwRoom;
            }
            else
            { 
                Move();
             
                timeBtwRoom= startTimeBtwRoom;  
                
                
            }
        }
        else
        {
            timeBtwRoom-= Time.deltaTime;
        }
        
    }
    private void  Move()
    {
      if(despDif==true)
            {

                    transform.position=posmove;
                    despDif=false;
                   
                   
                


            }
              else if(direction == 1 || direction == 2)
        {
             
            if(transform.position.x < maxX)
            {
                 
              
                    
                    
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                        
                        direcciones [i]=direction;
                       
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Debug.Log("direccion final"+direction);
                        stopGeneration = true;  
                        numHabit--;       
                    }
                    else
                    {
                        dire=direction;
                        int rand = Random.Range(0, rooms.Length);
                        direcciones [i]=direction;
                        i++;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                        int chance = Random.Range(1,11);
                         
                   Debug.Log(numHabit );     

                direction=Random.Range(1,9);
                while(direction==3||direction==4){
                    direction=Random.Range(1,9);
                }
                   Vector2 newPos=new Vector2(0,0);
                 
                if(direction==1 || direction==2){
                      newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(direction==5 || direction==6){
                    newPos = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(direction==7 || direction==8){
                    newPos = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                while(detectaroom==true)
                {
                    direction=Random.Range(1,9);
                    if(direction==3){
                        direction=5;
                    }
                    if(direction==4)
                    {
                        direction=8;
                    }
                     
                     if(direction==1 || direction==2){
                      newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(direction==5 || direction==6){
                    newPos = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(direction==7 || direction==8){
                    newPos = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                }
                transform.position = newPos;

                     if (chance<=3 && numHabit!=1)
                    { 

                        Debug.Log("hola1");
                        directionPos=Random.Range(1,4);
              if(directionPos==1){
                        directionPos=5;
                    }
                    if(directionPos==2)
                    {
                        directionPos=1;
                    }
                    if(directionPos==3)
                    {
                        directionPos=7;
                    }
                   
                 Vector2 newPos2=new Vector2(0,0);
                if(directionPos==1){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(directionPos==5){
                    newPos2 = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(directionPos==7){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroomPos = Physics2D.OverlapCircle(newPos2,1, room);









                       while(detectaroomPos==true || (directionPos==direction || directionPos+1==direction))
                       {
                            directionPos=Random.Range(1,4);
                    if(directionPos==1){
                        directionPos=5;
                    }
                    if(directionPos==2)
                    {
                        directionPos=1;
                    }
                    if(directionPos==3)
                    {
                        directionPos=7;
                    }
                     
                     if(directionPos==1){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(directionPos==5){
                    newPos2 = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(directionPos==7){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom = Physics2D.OverlapCircle(newPos2,1, room);
                       }
                        posmove = newPos2;



                        Preposibilidad();
                    }
                     
                    }
                                
                                
                
            }
            else
            {
                Debug.Log("borde derecha");
                direction= Random.Range(3,9);
            }
        }
        else if (direction == 3 || direction == 4)
        {
            
            if(transform.position.x > minX)
            {
                
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                     
                        direcciones [i]=direction;
                         
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                         numHabit--;       
                    }
                    else
                    {
                        int rand = Random.Range(0, rooms.Length);
                        direcciones [i]=direction;
                        i++;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                           posmove=transform.position;
                            Debug.Log(numHabit); 
                            

                            

                direction=Random.Range(3,9);
                   Vector2 newPos=new Vector2(0,0);
                 
                if(direction==3 || direction==4){
                    newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction==5 || direction==6){
                    newPos = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(direction==7 || direction==8){
                    newPos = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                while(detectaroom==true)
                {
                    direction=Random.Range(3,9);
                    
                if(direction==3 || direction==4){
                    newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction==5 || direction==6){
                    newPos = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(direction==7 || direction==8){
                    newPos = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                } 
                detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                }
                transform.position = newPos;


                    if (chance<=3 && numHabit!=1)
                    {
                       Debug.Log("hola2"); 

                        directionPos=Random.Range(1,4);
              if(directionPos==1){
                        directionPos=5;
                    }
                    if(directionPos==2)
                    {
                        directionPos=3;
                    }
                    if(directionPos==3)
                    {
                        directionPos=7;
                    }
                   
                 Vector2 newPos2=new Vector2(0,0);
                if(directionPos==3){
                      newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(directionPos==5){
                    newPos2 = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(directionPos==7){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroomPos = Physics2D.OverlapCircle(newPos2,1, room);









                       while(detectaroomPos==true || (directionPos==direction || directionPos+1==direction))
                       {
                            directionPos=Random.Range(1,4);
                    if(directionPos==1){
                        directionPos=5;
                    }
                    if(directionPos==2)
                    {
                        directionPos=3;
                    }
                    if(directionPos==3)
                    {
                        directionPos=7;
                    }
                     
                     if(directionPos==3){
                      newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(directionPos==5){
                    newPos2 = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(directionPos==7){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom = Physics2D.OverlapCircle(newPos2,1, room);
                       }
                        posmove = newPos2;




                        
                        Preposibilidad();
                    }
                     
                     
                    }

                
            }
            else
            {
                Debug.Log("borde izquierda");
                while(direction==3 || direction ==4)
                        {
                            direction=Random.Range(1,9);
                        } 
            }
        }
        else if (direction == 5 || direction == 6)
        {    
            if(transform.position.y > minY)
            {
               
                
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length); 
                        
                        direcciones [i]=direction;
                        
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                        numHabit--;       
                    }
                    else
                    {
                        int rand = Random.Range(0, rooms.Length);
                        direcciones [i]=direction;
                        i++;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                           posmove=transform.position;
                            Debug.Log(numHabit); 
                            
                        



                    direction=Random.Range(1,7);
                   Vector2 newPos=new Vector2(0,0);
                 
                if(direction==1 || direction==2){
                      newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(direction==3 || direction==4){
                    newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction==5 || direction==6){
                    newPos = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                while(detectaroom==true)
                {
                    direction=Random.Range(1,7);
                     
                if(direction==1 || direction==2){
                      newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(direction==3 || direction==4){
                    newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction==5 || direction==6){
                    newPos = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                }
                transform.position = newPos;


                    if (chance<=3 && numHabit!=1)
                    {
                        Debug.Log("hola3");


                        directionPos=Random.Range(1,4);
              if(directionPos==1){
                        directionPos=5;
                    }
                    if(directionPos==2)
                    {
                        directionPos=1;
                    }
                    if(directionPos==3)
                    {
                        directionPos=3;
                    }
                   

                 Vector2 newPos2=new Vector2(0,0);
                if(directionPos==1){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(directionPos==5){
                    newPos2 = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(directionPos==3){
                    newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                Collider2D detectaroomPos = Physics2D.OverlapCircle(newPos2,1, room);








                       while(detectaroomPos==true || (directionPos==direction || directionPos+1==direction))
                       {
                            directionPos=Random.Range(1,4);
                    if(directionPos==1){
                        directionPos=5;
                    }
                    if(directionPos==2)
                    {
                        directionPos=1;
                    }
                    if(directionPos==3)
                    {
                        directionPos=3;
                    }
                     
                     if(directionPos==1){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(directionPos==5){
                    newPos2 = new Vector2(transform.position.x, transform.position.y- moveAmount);
                }
                if(directionPos==3){
                    newPos2 = new Vector2(transform.position.x- moveAmount, transform.position.y);
                }
                detectaroom = Physics2D.OverlapCircle(newPos2,1, room);
                       }
                        posmove = newPos2;


                        
                        Preposibilidad();
                    }
                     
                      
                    }

                
            }
            else
            {
                Debug.Log("borde abajo");
                direction=Random.Range(1,9);

            }
        }
        else if (direction == 7 || direction ==8)
        {
           
            if(transform.position.y < maxY)
            {  
                    
                    if(numHabit==1)
                    {
                       int rand = Random.Range(0, rooms.Length);
                        direcciones [i]=direction;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Debug.Log("direccion final"+direction);
                        stopGeneration = true;    
                        numHabit--;       
                    }
                    else
                    {
                        int rand=Random.Range(0,rooms.Length);
                        direcciones [i]=direction;
                        i++;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                       posmove=transform.position;
                        Debug.Log(numHabit);
                      

                        direction=Random.Range(1,9);
                while(direction==5||direction==6){
                    direction=Random.Range(1,9);
                }
                   Vector2 newPos=new Vector2(0,0);
                
                if(direction==1 || direction==2){
                      newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
               if(direction==3 || direction==4){
                    newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction==7 || direction==8){
                    newPos = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                while(detectaroom==true)
                {
                    direction=Random.Range(1,9);
                    if(direction==5){
                        direction=1;
                    }
                    if(direction==6)
                    {
                        direction=3;
                    }
                     
                    if(direction==1 || direction==2){
                      newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
               if(direction==3 || direction==4){
                    newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction==7 || direction==8){
                    newPos = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                }
                transform.position = newPos;

               
                        if (chance<=3 && numHabit!=1)
                    {
                        

                        directionPos=Random.Range(1,4);
              if(directionPos==1){
                        directionPos=3;
                    }
                    if(directionPos==2)
                    {
                        directionPos=1;
                    }
                    if(directionPos==3)
                    {
                        directionPos=7;
                    } 
                   
                 Vector2 newPos2=new Vector2(0,0);
                if(directionPos==1){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(directionPos==3){
                    newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(directionPos==7){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroomPos = Physics2D.OverlapCircle(newPos2,1, room);










                       while(detectaroomPos==true || (directionPos==direction || directionPos+1==direction))
                       {
                            directionPos=Random.Range(1,4);
                    if(directionPos==1){
                        directionPos=3;
                    }
                    if(directionPos==2)
                    {
                        directionPos=1;
                    }
                    if(directionPos==3)
                    {
                        directionPos=7;
                    }
                     
                     if(directionPos==1){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(directionPos==3){
                    newPos2 = new Vector2(transform.position.x- moveAmount, transform.position.y);
                }
                if(directionPos==7){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom = Physics2D.OverlapCircle(newPos2,1, room);
                       }
                        posmove = newPos2;



                        
                        Preposibilidad();
                        
                    }
                   
                    }
                    
                
            }
            else
            {
                Debug.Log("borde arriba");
                direction=Random.Range(1,7);
            }
        }
    }

   
       
    private void Preposibilidad(){

        // Debug.Log("esta en posiblidad"); 
        int mitad=numHabit/2;
        //  Debug.Log("mitad es:"+mitad);
        Cantidad=Random.Range(1,mitad);
         Debug.Log("cantidad es"+Cantidad);
        numHabit=numHabit-Cantidad;
        direction2=direction;
        despDif=true; 
        direcciones2 = new int [Cantidad+4];
        i2=0;
        direcciones2[i2]=direcciones[i];
        i2++;
    }

    
       private void Posibilidad()
        {
            Debug.Log("direccion"+direcciones[i-1]);
            Debug.Log("direccion habit"+direction2);
            if(direction2 == 1 || direction2 == 2)
            {
                Debug.Log("habitacion num"+Cantidad);
            if(transform.position.x < maxX)
            {
                
                   if(Cantidad==1)
                    {
                        
                        int rand = Random.Range(0, rooms.Length);
                        direcciones2[i2]=direction2;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Debug.Log("entro");
                        
                        Cantidad--;
                        Debug.Log("Cantidad es 0 "+Cantidad);
                        direction=directionPos;
                        Debug.Log("las habit que faltan son:"+numHabit);
                    }
                    else
                    {

                    int rand = Random.Range(0, rooms.Length);
                    direcciones2[i2]=direction2;
                    i2++;
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(1,9);
                    while(direction2==3 || direction2 ==4)
                        {
                            direction2=Random.Range(1,9);
                        } 
                     
                   Vector2 newPos2=new Vector2(0,0);
                if(direction2==1 || direction2==2){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
               if(direction2==5 || direction2==6){
                    newPos2 = new Vector2(transform.position.x , transform.position.y- moveAmount);
                }
                if(direction2==7 || direction2==8){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroom2 = Physics2D.OverlapCircle(newPos2,1, room);
                while(detectaroom2==true)
                {
                    direction2=Random.Range(1,9);
                    if(direction2==3){
                        direction2=5;
                    }
                    if(direction2==4)
                    {
                        direction2=7;
                    }
                     
                    if(direction2==1 || direction2==2){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
               if(direction2==6 || direction2==5){
                    newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction2==7 || direction2==8){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom2 = Physics2D.OverlapCircle(newPos2,1, room);
                }
                transform.position = newPos2;


    
                   


                    }
                
            }
            else
            {
                direction2= Random.Range(3,9);
            }
             
        }
        else{ 
            if (direction2 == 3 || direction2 == 4)
        {
                        Debug.Log("habitacion num"+Cantidad);
            if(transform.position.x > minX)
            {
               
                   if(Cantidad==1)
                    {
                        
                        int rand = Random.Range(0, rooms.Length);
                        direcciones2[i2]=direction2;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity); 
                        // Debug.Log("entro");
                        
                        Cantidad--;
                        // Debug.Log("Cantidad es 0 "+Cantidad);
                        direction=directionPos;
                        // Debug.Log("las habit que faltan son:"+numHabit);
                    }
                    else
                    {

                    int rand = Random.Range(0, rooms.Length);
                    direcciones2[i2]=direction2;
                    i2++;
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(3,9);
                   
                     
                   Vector2 newPos2=new Vector2(0,0);
                if(direction2==3 || direction2==4){
                      newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
               if(direction2==5 || direction2==6){
                    newPos2 = new Vector2(transform.position.x , transform.position.y- moveAmount);
                }
                if(direction2==7 || direction2==8){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroom2 = Physics2D.OverlapCircle(newPos2,1, room);
                while(detectaroom2==true)
                {
                    direction2=Random.Range(3,9);
                    if(direction2==3 || direction2==4){
                      newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
               if(direction2==6 || direction2==5){
                    newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction2==7 || direction2==8){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom2 = Physics2D.OverlapCircle(newPos2,1, room);
                }
                transform.position = newPos2;


    
                   


                    }
                
            }
            else
            {
                while(direction2==3||direction2==4)
                {
                      direction2= Random.Range(1,9);
                }
              
            }
             
        }
        else{
             if (direction2 == 5 || direction2==6)
        {
               Debug.Log("habitacion num"+Cantidad);
            if(transform.position.y > minY)
            {
                
                   if(Cantidad==1)
                    {
                        
                        int rand = Random.Range(0, rooms.Length);
                        direcciones2[i2]=direction2;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Cantidad--;
                        direction=directionPos;
                        
                    }
                    else
                    {

                    int rand = Random.Range(0, rooms.Length);
                    direcciones2[i2]=direction2;
                    i2++;
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(1,7);
                   
                     
                   Vector2 newPos2=new Vector2(0,0);
                if(direction2==3 || direction2==4){
                      newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
               if(direction2==1 || direction2==2){
                    newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(direction2==7 || direction2==8){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroom2 = Physics2D.OverlapCircle(newPos2,1, room);
                while(detectaroom2==true)
                {
                    direction2=Random.Range(1,7);
                    if(direction2==3 || direction2==4){
                      newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
               if(direction2==1 || direction2==2){
                    newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
                if(direction2==7 || direction2==8){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom2 = Physics2D.OverlapCircle(newPos2,1, room);
                }
                transform.position = newPos2;


    
                   


                    }
                
            }
            else
            {
                while(direction2==5||direction2==6)
                {
                      direction2= Random.Range(1,9);
                }
            }
             
        }
        else {
        if (direction2 == 7 || direction2 == 8)
        {
          Debug.Log("habitacion num"+Cantidad);
            if(transform.position.y < maxY)
            {  
                
               if(Cantidad==1)
                    {
                        
                        int rand = Random.Range(0, rooms.Length);
                        direcciones2[i2]=direction2;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Debug.Log("entro");
                        
                        Cantidad--;
                        Debug.Log("Cantidad es 0 "+Cantidad);
                        direction=directionPos;
                        Debug.Log("las habit que faltan son:"+numHabit);
                    }
                    else
                    {

                    int rand = Random.Range(0, rooms.Length);
                    direcciones2[i2]=direction2;
                    i2++;
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(1,9);
                    while(direction2==5 || direction2 ==6)
                        {
                            direction2=Random.Range(1,9);
                        } 
                     
                   Vector2 newPos2=new Vector2(0,0);
                if(direction2==1 || direction2==2){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
               if(direction2==3 || direction2==4){
                    newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction2==7 || direction2==8){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                Collider2D detectaroom2 = Physics2D.OverlapCircle(newPos2,1, room);
                while(detectaroom2==true)
                {
                    direction2=Random.Range(1,9);
                    if(direction2==5){
                        direction2=1;
                    }
                    if(direction2==6)
                    {
                        direction2=4;
                    }
                     
                    if(direction2==1 || direction2==2){
                      newPos2 = new Vector2(transform.position.x + moveAmount, transform.position.y);
                }
               if(direction2==3 || direction2==4){
                    newPos2 = new Vector2(transform.position.x - moveAmount, transform.position.y);
                }
                if(direction2==7 || direction2==8){
                    newPos2 = new Vector2(transform.position.x, transform.position.y+ moveAmount);
                }
                detectaroom2 = Physics2D.OverlapCircle(newPos2,1, room);
                }
                transform.position = newPos2;


    
                   


                    }
                
            }
            else
            {
                
                      direction2= Random.Range(1,7);
                
            }
        }
        }
        }
    }
}
}
    

