using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour
{
    public static MoveController instance;
    public enum Direction { 
    Left, Right, Up, Down}
    bool[] swipe = new bool[4];
    [SerializeField] GameObject player;

    Vector2 startTouch;
    bool touchMoved;
    Vector2 swipeDelta;
    const float SWIPE_THRESHOLD = 50;

  

    Vector2 TouchPosition()
    { return (Vector2)Input.mousePosition; }
    bool TouchBegan()
    {
        return Input.GetMouseButtonDown(0);
    }
    bool TouchEnded()
    {
        return Input.GetMouseButtonUp(0); }
                bool GetTouch() { return Input.GetMouseButton(0); }
            
        
    
    private void Awake()
    {
        instance = this;
    
    }
    private void Update()
    {
        if (TouchBegan())
        {
            startTouch = TouchPosition();
            touchMoved = true;
        }
        else if (TouchEnded() && touchMoved == true) {
            SendSwipe();
            touchMoved = false;
        }
        swipeDelta = Vector2.zero;
        if (touchMoved && GetTouch()) {
            swipeDelta = TouchPosition() - startTouch;
        }
        if (swipeDelta.magnitude > SWIPE_THRESHOLD) {
            if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
            {
                if (swipe[(int)Direction.Left] = swipeDelta.x < 0) { player.GetComponent<Player>().MovingLeft(); }


                else if (swipe[(int)Direction.Right] = swipeDelta.x > 0) { player.GetComponent<Player>().MovingRight(); }
                
               

            }
            else {
                if (swipe[(int)Direction.Down] = swipeDelta.y > 0) { player.GetComponent<Player>().Attack(); } 
                swipe[(int)Direction.Up] = swipeDelta.y < 0;
            }
            SendSwipe();
        }
    }
    void SendSwipe() {
        if (swipe[0] || swipe[1] || swipe[2] || swipe[3])
        {
            Debug.Log(swipe[0] + "|" + swipe[1] + "|" + swipe[2] + "|" + swipe[3]);
        }
        else { Debug.Log("Click"); }
        Reset();
    }
    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        touchMoved = false;
        for (int i = 0; i < 4; i++) {
            swipe[i] = false;
        }
    }

}

