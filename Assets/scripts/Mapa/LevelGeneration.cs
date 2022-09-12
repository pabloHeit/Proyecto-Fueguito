using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; // index 0 --> LR, index 1 --> LRB, index 2 --> LRT, index 3 --> LRBT
    public int[] direcciones;
    public int i=0;
    public int direction;
    public int direction2;
    public bool posi;
    public float moveAmount;
    public float timeBtwRoom;
    public float startTimeBtwRoom = 0.25f;
    public float minX;
    private int Cantidad;
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
        Debug.Log(direction);
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
        
   
        
        if(direction == 1 || direction == 2)
        {
             
            if(transform.position.x < maxX)
            {
                  if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
              
                    
                    
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                        
                        direcciones [i]=direction;
                       direction=0;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Debug.Log("direccion final"+direction);
                        stopGeneration = true;         
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
                 if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
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
                        posmove=transform.position;
                        
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
                  if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
               
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                     
                        direcciones [i]=direction;
                           direction=0;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                         
                    }
                    else
                    {
                        int rand = Random.Range(0, rooms.Length);
                        direcciones [i]=direction;
                        i++;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                            Debug.Log(numHabit); 
                            

                            

                direction=Random.Range(3,9);
                   Vector2 newPos=new Vector2(0,0);
                 if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
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
                        posmove=transform.position;
                        
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
                  if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
                
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length); 
                        
                        direcciones [i]=direction;
                        direction=0;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                        
                    }
                    else
                    {
                        int rand = Random.Range(0, rooms.Length);
                        direcciones [i]=direction;
                        i++;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                            Debug.Log(numHabit); 
                            
                        



                    direction=Random.Range(1,7);
                   Vector2 newPos=new Vector2(0,0);
                 if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
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
                        posmove=transform.position;
                        
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
                  if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
                
                     
                    
                    
                    if(numHabit==1)
                    {
                       int rand = Random.Range(0, rooms.Length);
                        
                        direcciones [i]=direction;
                        direction=0;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Debug.Log("direccion final"+direction);
                        stopGeneration = true;    
                        
                    }
                    else
                    {
                        int rand=Random.Range(0,rooms.Length);
                        direcciones [i]=direction;
                        i++;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                      
                        Debug.Log(numHabit);
                      

                        direction=Random.Range(1,9);
                while(direction==5||direction==6){
                    direction=Random.Range(1,9);
                }
                   Vector2 newPos=new Vector2(0,0);
                 if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
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
                        posmove=transform.position;
                        
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
/*posi=true;
        Debug.Log("esta en posiblidad"); 
        int mitad=numHabit/2;
         Debug.Log("mitad es:"+mitad);
        Cantidad=Random.Range(1,mitad);
         Debug.Log("cantidad es"+Cantidad);
        numHabit=numHabit-Cantidad;
        direction2=Random.Range(1,9);
        despDif=true; */
    }

    
       private void Posibilidad()
        {
         Debug.Log("habitacion num"+Cantidad);
            Debug.Log("direccion habit"+direction2);
            if(direction2 == 1 || direction2 == 2)
            {
                Debug.Log("habitacion num"+Cantidad);
            if(transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                
                if(detectaroom==true)
                {
                    direction2=Random.Range(3,9);
                }
                else
                {
                    
                    transform.position = newPos;
                   if(Cantidad==1)
                    {
                      
                         
                        direction2=0; 
                        posi=false;
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                       
                        Cantidad--;
                       Debug.Log("Cantidad es 0");
                       direcciones[i]=direction2;
                    i++;
                        direction=Random.Range(1,9);
                    }
                    else
                    {
                    int rand = Random.Range(0, rooms.Length);
                    direcciones[i]=direction2;
                    i++;
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(1,9);
                    while(direction2==3 || direction2 ==4)
                        {
                            direction2=Random.Range(1,9);
                        } 
                     
                    
                    }
                }
            }
            else
            {
                direction2= Random.Range(3,9);
            }
             
        }
        else if (direction2 == 3 || direction2 == 4)
        {
            Debug.Log("habitacion num"+Cantidad);
            if(transform.position.x > minX)
            {

                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                     direction=Random.Range(1,9);
                    while(direction2==3 || direction2==4){
                        direction2=Random.Range(1,9);
                    }
                }
                else
                {
                    
                    transform.position = newPos;
                   if(Cantidad==1)
                    {
                        
                          
                         direction2=0; 
                        posi=false;
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                       
                        Cantidad--;
                       Debug.Log("Cantidad es 0");
                      direcciones[i]=direction2;
                    i++;
                        direction=Random.Range(1,9);
                    }
                    else
                    {
                    int rand = Random.Range(0, rooms.Length);
                    direcciones[i]=direction2;
                    i++;
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction=Random.Range(1,9);
                    while(direction2==3 || direction2 ==4)
                        {
                            direction2=Random.Range(1,9);
                        } 
                     
                    
                    }
                }
            }
        }
        else if (direction2 == 5 || direction2==6)
        {
Debug.Log("habitacion num"+Cantidad);
            if(transform.position.y > minY)
            {
               
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                     direction=Random.Range(1,9);
                    while(direction2==5 || direction2==6){
                        direction2=Random.Range(1,9);
                    }
                }
                else
                {
                    
                    transform.position = newPos;
                   if(Cantidad==1)
                    {
                         
                        posi=false;
                        direction2=0; 
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                       
                        Cantidad--;
                       Debug.Log("Cantidad es 0");
                        direcciones[i]=direction2;
                    i++;
                        direction=Random.Range(1,9);
                    }
                    else
                    {
                    int rand = Random.Range(0, rooms.Length);
                    direcciones[i]=direction2;
                    i++;
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(1,9);
                    while(direction2==5 || direction2 ==6)
                        {
                            direction2=Random.Range(1,9);
                        } 
                     
                    
                    }
                }
            }
        }
        else if (direction2 == 7 || direction2 == 8)
        {
          Debug.Log("habitacion num"+Cantidad);
            if(transform.position.y < maxY)
            {  

                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                     direction2=Random.Range(1,7);
                }
                else
                {
                    
                    transform.position = newPos;
                   if(Cantidad==1)
                    {
                        
                         
                        direction2=0; 
                        posi=false;
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                       
                        Cantidad--;
                       Debug.Log("Cantidad es 0");
                       direcciones[i]=direction2;
                    i++;
                        direction=Random.Range(1,9);
                    }
                    else
                    {
                    int rand = Random.Range(0, rooms.Length);
                    direcciones[i]=direction2;
                    i++;
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(1,7);
                  
                    }
                }
            }
        }
     

    }
}
    
    

