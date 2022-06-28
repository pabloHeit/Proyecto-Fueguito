using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; // index 0 --> LR, index 1 --> LRB, index 2 --> LRT, index 3 --> LRBT

    private int direction;
    private int direction2;
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
    

    private int topCounter;
    private int downCounter;

    void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction= Random.Range(1, 7);
        Debug.Log(direction);
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
                topCounter=0;
                downCounter= 0;
                if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                    direction=Random.Range(5,7);
                }
                else
                {
                    
                    transform.position = newPos;
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                    }
                    else
                    {
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                        int chance = Random.Range(1,11);
                   

                        direction=Random.Range(1,7);
                        if(direction==3)
                        {
                            direction=2;
                        }
                        else if(direction==4)
                        {
                            direction=Random.Range(5,7);
                        }  
                   Debug.Log(numHabit);
                     if (chance<=3)
                    { 
                        posmove=transform.position;
                        Posibilidad();
                    }
                     
                    }
                                
                                
                }
            }
            else
            {
                direction= Random.Range(5,7);
            }
        }
        else if (direction == 3 || direction == 4)
        {
            
            if(transform.position.x > minX)
            {
                downCounter= 0;
                topCounter=0;
                if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                    direction=Random.Range(5,7);
                }
                else
                {
                    transform.position = newPos;
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                    }
                    else
                    {
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                            direction=Random.Range(3,7);
                            Debug.Log(numHabit); 
                    if (chance<=3)
                    {
                        posmove=transform.position;
                        Posibilidad();
                    }
                      
                    }

                }
            }
            else
            {
                direction= Random.Range(5,7);
            }
        }
        else if (direction == 5)
        { 
            if(transform.position.y > minY)
            {
                downCounter++;
            topCounter=0;
                if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
                Vector2 newposTD= new Vector2(transform.position.x, transform.position.y- moveAmount);

                Collider2D detectaroom = Physics2D.OverlapCircle(newposTD,1, room);
                if(detectaroom==true)
                {
                    direction=Random.Range(1,5);
                }
                else
                {

                    Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,1, room);
                    if(roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type !=3)
                    {
                        if(downCounter>=2)
                        {
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                            Instantiate(rooms[3], transform.position, Quaternion.identity);
                        }
                        else
                        {  
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                            int randBottomRoom = Random.Range(1, 4);

                            if(randBottomRoom == 2)
                            {
                                randBottomRoom = 1;
                            }

                                Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);     
                        }
                    }
                    Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                    transform.position = newPos;
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                    }
                    else
                    {  
                        int rand = Random.Range(2, 4);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                  
                        direction=Random.Range(1,7);
                    while(direction==6)
                    {
                        direction=Random.Range(1,7);
                    }  
                    Debug.Log(numHabit);
                    if (chance<=3)
                    {
                        posmove=transform.position;
                        Posibilidad();
                    }
                     
                    }
                  
                }
            }
            else
            {
                direction=Random.Range(1,5);

            }
        }
        else if (direction == 6)
        {
           
            if(transform.position.y < maxY)
            {  
                Debug.Log("empezo arriba");
                topCounter++;
                downCounter=0;
                if(despDif==true)
                {
                    transform.position=posmove;
                    despDif=false;
                }
                Vector2 newposTD= new Vector2(transform.position.x, transform.position.y+ moveAmount);

                Collider2D detectaroom = Physics2D.OverlapCircle(newposTD,1, room);
               
                if(detectaroom==true)
                {
                    direction=Random.Range(1,5);
                }
                else
                {
                    Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,1, room);

                    if(roomDetection.GetComponent<RoomType>().type !=2 && roomDetection.GetComponent<RoomType>().type !=3)
                    {
                        if(topCounter>=2)
                        {
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                            Instantiate(rooms[3], transform.position, Quaternion.identity);
                        }
                        else
                        {  
                            
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                            int randTopRoom = Random.Range(2, 4);

                        

                            Instantiate(rooms[randTopRoom], transform.position, Quaternion.identity);     
                        }
                    }
                    

                    Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveAmount);
                    transform.position = newPos;
                    if(numHabit==1)
                    {
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        stopGeneration=true;
                    }
                    else
                    {
                        int rand = Random.Range(1, 4);
                        if(rand==2)
                        {
                            rand=1;
                        }


                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        numHabit--;
                          int chance = Random.Range(1,11);
                   
                        direction=Random.Range(1,7);
                        while(direction==5)
                        {
                            direction=Random.Range(1,7);
                        } 
                        Debug.Log(numHabit);
                        if (chance<=3)
                    {
                        posmove=transform.position;
                        Posibilidad();
                    }
                     
                    }
                }
            }
            else
            {
                direction=Random.Range(1,5);
            }
        }
    }

    private void Posibilidad ()
    {
        Debug.Log("esta en posiblidad"); 
        int mitad=numHabit/2;
         Debug.Log("mitad es:"+mitad);
        Cantidad=Random.Range(1,mitad);
         Debug.Log("cantidad es"+Cantidad);
        numHabit=numHabit-Cantidad;
        while( Cantidad>0 )
        {
        
        direction2=Random.Range(1,7);
        if(direction2 == 1 || direction2 == 2)
        {

            if(transform.position.x < maxX)
            {
                topCounter=0;
                downCounter= 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                    direction2=Random.Range(5,7);
                }
                else
                {
                    
                    transform.position = newPos;
                   
                    int rand = Random.Range(0, rooms.Length);
                    Instantiate(rooms[rand], transform.position,Quaternion.identity);
                    Cantidad--;
                    direction2=Random.Range(1,7);
                    if(direction2==3)
                    {
                        direction2=2;
                    }
                    else if(direction2==4)
                    {
                        direction2=Random.Range(5,7);
                    }                       
                }
            }
            else
            {
                direction2= Random.Range(5,7);
            }
        }
        else if (direction2 == 3 || direction2 == 4)
        {
            if(transform.position.x > minX)
            {
                downCounter= 0;
                topCounter=0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                Collider2D detectaroom = Physics2D.OverlapCircle(newPos,1, room);
                if(detectaroom==true)
                {
                    direction2=Random.Range(5,7);
                }
                else
                {
                    transform.position = newPos;
                    
                        int rand = Random.Range(0, rooms.Length);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Cantidad--;
                        direction2=Random.Range(3,7);
                    
                }
            }
            else
            {
                direction2= Random.Range(5,7);
            }
        }
        else if (direction2 == 5)
        {
            downCounter++;
            topCounter=0;
            if(transform.position.y > minY)
            {
                Vector2 newposTD= new Vector2(transform.position.x, transform.position.y- moveAmount);

                Collider2D detectaroom = Physics2D.OverlapCircle(newposTD,1, room);
                        if(detectaroom==true)
                {
                    direction2=Random.Range(1,5);
                }
                else
                {

                    Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,1, room);
                    if(roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type !=3)
                    {
                        if(downCounter>=2)
                        {
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                            Instantiate(rooms[3], transform.position, Quaternion.identity);
                        }
                        else
                        {  
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                            int randBottomRoom = Random.Range(1, 4);

                            if(randBottomRoom == 2)
                            {
                                randBottomRoom = 1;
                            }

                                Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);     
                        }
                    }
                    Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                    transform.position = newPos;
                    
                        int rand = Random.Range(2, 4);
                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Cantidad--;
                        direction2=Random.Range(1,7);
                    while(direction2==6)
                    {
                        direction2=Random.Range(1,7);
                    }
                    
                  
                }
            }
            else
            {
                direction2=Random.Range(1,5);

            }
        }
        else if (direction2 == 6)
        {
          
            if(transform.position.y < maxY)
            {  
                Debug.Log("empezo arriba");
                topCounter++;
                downCounter=0;

                Vector2 newposTD= new Vector2(transform.position.x, transform.position.y+ moveAmount);

                Collider2D detectaroom = Physics2D.OverlapCircle(newposTD,1, room);
               
                if(detectaroom==true)
                {
                    direction2=Random.Range(1,5);
                }
                else
                {
                    Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,1, room);

                    if(roomDetection.GetComponent<RoomType>().type !=2 && roomDetection.GetComponent<RoomType>().type !=3)
                    {
                        if(topCounter>=2)
                        {
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                            Instantiate(rooms[3], transform.position, Quaternion.identity);
                        }
                        else
                        {  
                            
                            roomDetection.GetComponent<RoomType>().RoomDestruction();
                            int randTopRoom = Random.Range(2, 4);

                        

                            Instantiate(rooms[randTopRoom], transform.position, Quaternion.identity);     
                        }
                    }

                    Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveAmount);
                    transform.position = newPos;
                  
                        int rand = Random.Range(1, 4);
                        if(rand==2)
                        {
                            rand=1;
                        }


                        Instantiate(rooms[rand], transform.position,Quaternion.identity);
                        Cantidad--;
                        direction2=Random.Range(1,7);
                        while(direction2==5)
                        {
                            direction2=Random.Range(1,7);
                        }
                    
                }
            }
            else
            {
                direction2=Random.Range(1,5);
            }
        }

    }
    despDif=true;
    }
}
