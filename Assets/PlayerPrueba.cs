using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerPrueba : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputActions;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _pointShoot;
    [SerializeField] private Vector2 initialPosition = new Vector2(0, -2);
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        transform.position = initialPosition;
        _rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
       
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            Instantiate(_gameObject, _pointShoot.position, Quaternion.identity);
        }
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 clickPoint = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
            RaycastHit2D hit2D = Physics2D.Raycast(clickPoint, Vector3.forward, 12f);
            if (hit2D)
            {
                Debug.Log(hit2D.collider.gameObject.name);
                AudioClip clip = null;
                foreach(var kvp in AudioManager.Instance.clipList)
                {
                    if(AudioManager.Instance.clipList.ContainsKey(AudioClips.Yamete))
                    {
                        clip = kvp.Value;
                    }
                }
                AudioSource audioSource = GetComponent <AudioSource>();
                if(clip!=null)
                {
                    audioSource.clip = clip;
                }
                audioSource.Play();
                if (_spriteRenderer.color == Color.red)
                {
                    _spriteRenderer.color = Color.black;
                }
                else
                {

                    _spriteRenderer.color = Color.red;
                }
            }
        }
        if(context.performed)
        Debug.Log(Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>()));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
       _rb.linearVelocity= context.ReadValue<Vector2>() * 5;
       
    }
}
/* private void Awake()
   {
       //Se ejecuta el primero. 
   }
   private void OnEnable()
   {
      //Siempre que se activa el objeto 
   }
   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {

   }
   private void OnDisable()
   {

   }

   // Update is called once per frame
   void Update()
   {
      // se ejecuta en cada frame 
   }

   private void LateUpdate()
   {

   }
   private void FixedUpdate()
   {

   }
   private void OnDestroy()
   {

   }*/
