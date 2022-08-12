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
    private int numHabit=10;
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

  

    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction= Random.Range(1, 9);
        Debug.Log(direction);
        direcciones = new int [11];
         direcciones [i]=direction;
    i++;
    }


    private void Update() 
    {
       
       
        if(timeBtwRoom <=0 && stopGeneration == false)
        {
            Move();
            timeBtwRoom= startTimeBtwRoom;
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
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                    direction=Random.Range(3,9);
                }
                else
                {
                    
                    transform.position = newPos;
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                        direction=0;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                        
                    }
                    else
                    {
                        dire=direction;
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                        int chance = Random.Range(1,11);
                   Debug.Log(numHabit );     
                    direction=Random.Range(1,9);
                    while(direction==3 || direction ==4)
                        {
                            direction=Random.Range(1,9);
                        } 
                     if (chance<=3 && numHabit!=1)
                    { 
                        posmove=transform.position;
                        Posibilidad();
                    }
                     direcciones [i]=direction;
    i++;
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
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                    direction=Random.Range(1,9);
                    while(direction==3 || direction==4)
                    {
                    direction=Random.Range(1,9);
                }
                }
                else
                {
                    transform.position = newPos;
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                        direction=0;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                         
                    }
                    else
                    {
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                            Debug.Log(numHabit); 
                            direction=Random.Range(3,9);
                    if (chance<=3 && numHabit!=1)
                    {
                        posmove=transform.position;
                        Posibilidad();
                    }
                     
                      direcciones [i]=direction;
    i++;
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
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                    direction=Random.Range(1,9);
                    while(direction==5 || direction==6)
                    {
                    direction=Random.Range(1,9);
                    }
                }
                else
                {
                    transform.position = newPos;
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length); 
                        direction=0;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                        
                    }
                    else
                    {
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                            Debug.Log(numHabit); 
                            direction=Random.Range(1,9);
                    if (chance<=3 && numHabit!=1)
                    {
                        posmove=transform.position;
                        Posibilidad();
                    }
                      direcciones [i]=direction;
    i++;
                      
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
                Vector2 newposTD= new Vector2(transform.position.x, transform.position.y+ moveAmount);

                Collider2D detectaroom = Physics2D.OverlapCircle(newposTD,1, room);
               
                if(detectaroom==true)
                {

                    direction=Random.Range(1,7);
                }
                else
                {
                    
                    

                    Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveAmount);
                    transform.position = newPos;
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                         direction=0;
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                        
                    }
                    else
                    {
                        int rand=Random.Range(0,rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                      
                        Debug.Log(numHabit);
                        direction=Random.Range(1,9); 
                      while(direction==5 || direction==6)
                   {
                       direction=Random.Range(1,9); 
                   }
                        if (chance<=3 && numHabit!=1)
                    {
                        posmove=transform.position;
                        Posibilidad();
                    }
                     direcciones [i]=direction;
    i++;
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

    private void Posibilidad ()
    {
        posi=true;
        Debug.Log("esta en posiblidad"); 
        int mitad=numHabit/2;
         Debug.Log("mitad es:"+mitad);
        Cantidad=Random.Range(1,mitad);
         Debug.Log("cantidad es"+Cantidad);
        numHabit=numHabit-Cantidad;
        direction2=direction;
    while( Cantidad>0 )
        {Posibilidad2();}

    }
       private void Posibilidad2()
        {
         
            direction2=Random.Range(1,9);
            if(direction2 == 1 || direction2 == 2)
            {

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
                   
                    int rand = Random.Range(0, rooms.Length);
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(1,9);
                     direcciones [i]=direction2;
         i++;
                }
            }
            else
            {
                direction2= Random.Range(3,9);
            }
        }
        else if (direction2 == 3 || direction2 == 4)
        {
            if(transform.position.x > minX)
            {

                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                    direction2=Random.Range(3,9);
                }
                else
                {
                    transform.position = newPos;
                    
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Cantidad--;
                        direction2=Random.Range(1,9);
                         direcciones [i]=direction2;
         i++;
                }
            }
            else
            {
                while(direction==3 || direction ==4)
                        {
                            direction=Random.Range(1,9);
                        } 
            }
        }
        else if (direction2 == 5 || direction2==6)
        {

            if(transform.position.y > minY)
            {
                Vector2 newposTD= new Vector2(transform.position.x, transform.position.y- moveAmount);

                Collider2D detectaroom = Physics2D.OverlapCircle(newposTD,1, room);
                        if(detectaroom==true)
                {
                    while(direction==5 || direction ==6)
                        {
                            direction=Random.Range(1,9);
                        } 
                }
                else
                {

                    Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,1, room);
                    Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                    transform.position = newPos;
                    
                        int rand = Random.Range(1, 4);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Cantidad--;
                        direction2=Random.Range(1,9);
                         direcciones [i]=direction2;
         i++;
                  
                }
            }
            else
            {
                while(direction==5 || direction ==6)
                        {
                            direction=Random.Range(1,9);
                        } 

            }
        }
        else if (direction2 == 7 || direction == 8)
        {
          
            if(transform.position.y < maxY)
            {  

                Vector2 newposTD= new Vector2(transform.position.x, transform.position.y+ moveAmount);

                Collider2D detectaroom = Physics2D.OverlapCircle(newposTD,1, room);
               
                if(detectaroom==true)
                {
                    direction2=Random.Range(1,7);
                }
                else
                {
                    Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,1, room);

                    

                    Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveAmount);
                    transform.position = newPos;
                  
                        int rand = Random.Range(1, 4);
                        if(rand==2)
                        {
                            rand=1;
                        }


                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Cantidad--;
                        direction2=Random.Range(1,9);
                         direcciones [i]=direction2;
         i++;
                }
            }
            else
            {
                direction2=Random.Range(1,7);
            }
        }
direction2=0;
direction=Random.Range(1,9);
    despDif=true; 
    posi=false;
    }
}
    
    

