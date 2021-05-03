using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 enum PlayerState
{  
    leftMoving,
    rightMoving,
    leftStanding,
    rightStanding,
    attack,
    death,
        idle

}
public class Player : MonoBehaviour
{
    public static int score;
    [SerializeField] private GameObject _canAttackImg;
    [SerializeField] private GameObject _weapon;
    [SerializeField] GameObject _loseScreen;
    [SerializeField] Sounds sounds;
    [SerializeField] Transform _collider2D;
    PlayerState currentState;
    private bool _isGrounded;
    private bool _alredyRight = false;
    private bool _alredyLeft = false;
    private bool _canAttack = true;
    
    private float _speed = 8f;
    private float _attackForce = 35f;
    private static Animator _animator;
    Rigidbody2D _rb;
    Vector3 vec;
    public static float _scoreFloat;
    public static int _scoreEnemy;
    public static bool _isAlive = true;
    

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        currentState = PlayerState.idle;
        
        _animator = GetComponent<Animator>();
        
        
    }


    void Update()
    { if (_isAlive)
        {
            MovingControl();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
            }
       


            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                MovingRight();
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {

                MovingLeft();
            }
            Score();
            
            Standing();
            




        }
   

    }
    private void MovingControl()
    {
        if (currentState == PlayerState.rightMoving && !_alredyRight)
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (currentState == PlayerState.leftMoving && !_alredyLeft)
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        else transform.position = transform.position;
    }

    public void MovingLeft()
    {
        currentState = PlayerState.leftMoving;
        
        _speed = 8f;
        if (_alredyLeft)
        {
            _isGrounded = true;
            currentState = PlayerState.leftStanding;
            _animator.SetInteger("State", 0);
        }
        else
        _animator.SetInteger("State", 1);

        if (!_alredyLeft)
        {
            sounds.PlayFlySound();
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            
        }
       
    }
    public void MovingRight()
    {
        currentState = PlayerState.rightMoving;
     
        _speed = 8f;
        if (_alredyRight)
        {
            _isGrounded = true;
            currentState = PlayerState.rightStanding;
            _animator.SetInteger("State", 0);
        }
        else
        _animator.SetInteger("State", 1);

        if (!_alredyRight) {
            sounds.PlayFlySound();
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            
        }
       


    }

  public void Attack()
    {if (_canAttack && _isGrounded) {
            if (_alredyLeft || _alredyRight) {
                vec = Vector3.up;
                    StartCoroutine(AttackCo()); }
            else if (!_alredyLeft && !_alredyRight && currentState == PlayerState.rightStanding ) {
                vec = Vector3.right;
                StartCoroutine(AttackCo());
            }
            else if (!_alredyLeft && !_alredyRight && currentState == PlayerState.leftStanding )
            {
                vec = Vector3.left;
                StartCoroutine(AttackCo());
            }

        }
    }
    public void PlayerStateV() {
        if (currentState == PlayerState.leftMoving) {
            print("LeftMoving");
        }
        if (currentState == PlayerState.rightMoving)
        {
            print("rightMoving");
        }
        if (currentState == PlayerState.rightStanding)
        {
            print("rightStanding");
        }
        if (currentState == PlayerState.leftStanding)
        {
            print("Leftstanding");
        }
        if (currentState == PlayerState.attack)
        {
            print("attack");
        }
        if (currentState == PlayerState.idle)
        {
            print("idle");
        }
        if (_isGrounded)
        {
            print("isGrounded");
        }
        if (!_isGrounded)
        {
            print("isNOTGrounded");
        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            transform.localRotation = Quaternion.Euler(0, 180, 90);
            _alredyLeft = true;
            _isGrounded = true;
            _animator.SetInteger("State", 0);
            _speed = 0;
        }
        if (collision.gameObject.tag == "RightWall")
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            _alredyRight = true;
            _isGrounded = true;
            _animator.SetInteger("State", 0); 
            _speed = 0;
        }
        if (collision.gameObject.tag == "Enemy" && _canAttack)
        {
            Death();
        }
        if (collision.gameObject.tag == "Lava")
        {
            Death();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            transform.localRotation = Quaternion.Euler(0, 180, 90);
            _alredyLeft = true;
            _isGrounded = true;
            _animator.SetInteger("State", 0);
            _speed = 0;
        }
        if (collision.gameObject.tag == "RightWall")
        {
            transform.localRotation = Quaternion.Euler(0, 0, 90);
            _alredyRight = true;
            _isGrounded = true;
            _animator.SetInteger("State", 0);
            _speed = 0;
        }
    }
        private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            _alredyLeft = false;
            _speed = 8f;
            _isGrounded = false;
            transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (collision.gameObject.tag == "RightWall")
        {
            _alredyRight = false;
            _speed = 8f;
            _isGrounded = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            _alredyLeft = false;
            _alredyRight = false;
            StartCoroutine(BodyType());
            _animator.SetInteger("State", 3);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGrounded = false;
        if (collision.gameObject.tag == "Platform")
        {
            if (currentState == PlayerState.rightStanding)
            {
                currentState = PlayerState.rightMoving;
                _speed = 8;
            }
            if (currentState == PlayerState.leftStanding)
            {
                currentState = PlayerState.leftMoving;
                _speed = 8;
            }
          


        }


    }
    IEnumerator BodyType()
    {
        _speed = 0.5f;
        yield return new WaitForSeconds(0.1f);
        _speed = 0.4f;
        yield return new WaitForSeconds(0.1f);
        _speed = 0.3f;
        if (currentState == PlayerState.rightMoving) {
            currentState = PlayerState.rightStanding;
            _isGrounded = true;
        }
        if (currentState == PlayerState.leftMoving) {
            currentState = PlayerState.leftStanding;
            _isGrounded = true;
        }
        yield return new WaitForSeconds(0.1f);
        _speed = 0.2f;
        yield return new WaitForSeconds(0.1f);
        _speed = 0.1f;
        yield return new WaitForSeconds(0.1f);
        _speed = 0;
        yield return new WaitForSeconds(0.1f);

    }
    IEnumerator AttackCo() {
        _animator.SetInteger("State", 2);
        sounds.PlayAttackSound();
        _weapon.SetActive(true);
            _canAttack = false;
        _canAttackImg.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            transform.position += vec * _attackForce * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            transform.position += vec * _attackForce * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            transform.position += vec * _attackForce * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            transform.position += vec * _attackForce * Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            transform.position += vec * _attackForce * Time.deltaTime;
        _animator.SetInteger("State", 0);
        _weapon.SetActive(false);
            yield return new WaitForSeconds(0.8f);
        _canAttack = true;
        _canAttackImg.SetActive(true);
      
    }

    private void Score() {
        _scoreFloat = GetComponent<Transform>().position.y;
        score = _scoreEnemy +  (int)_scoreFloat * 10;
    }
    public static int GetScore() {
        return score;
    }
    public static float RecountScore()
    {
        return _scoreEnemy += 50;
       
    }
    private void Death() {
        _isAlive = false;
        sounds.PlayLoseSound();
        GetComponent<Collider2D>().enabled = false;
        _animator.SetBool("Dead", true);
        Invoke("Lose", 2f);
    }
    private void Lose() {
        Time.timeScale = 0f;
        _loseScreen.SetActive(true);
        if (PlayerPrefs.GetInt("Score") < score)
        {

            PlayerPrefs.SetInt("Score", score);
        }

    }
    public static void ContinueGame() {

        Time.timeScale = 1f;
        _isAlive = true;
        _animator.SetBool("Dead", false);
    }
   

    private void Standing()
    {
        if (currentState == PlayerState.idle)
        {
            _animator.SetInteger("State", 3);
        }

    }

}

    

