using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactorBall = 0.2f;

    //cached component references (ilerde sesleri kullanmak istersek vs.)

    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    //state

    Vector2 paddleToBallVector;
    bool hasStarted = false; //Başlangıç olarak false olarak atandı.


    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position; // burada yapıştırdık fakat hareket halinde değil. Update kısmında hareket ettikten sonra takip etmesi için kod yazdık.
       myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {

        if (!hasStarted)  // Burada dediği şey; hasStarted == false, yani eğer bu iddaa doğruysa, hasStarted False'a tekabul ediyorsa, alttaki işlemi yap. Değilse yapma.  Başlangıçta bir şey yapmadığımız için (tuşa basmak) false olduğu için çalıştı fakat
        {                 //  ReleaseBallOnClick' çalıştırıldığında hasStarted komutunun true olduğunu gördü ve çalıştırmadı.

            LockBallToPaddle();

            ReleaseBallOnClick();


            
        }
        

        
    }

    private void ReleaseBallOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
                    hasStarted = true;
                    myRigidBody2D.velocity = new Vector2(xPush, yPush);

        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactorBall),  // X Value 
            Random.Range(0f, randomFactorBall)); // Y value


        if (hasStarted) // Eğer hasStarted true ise çal. Böylece başlangıçta değse de çalışmadı.
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip); // PlayOneShot = Interrupt edilmeden sesin çalmasını sağlar. 
            myRigidBody2D.velocity += velocityTweak; // Oluşturduğumuz UnBoring Loop'u has started komutuyla çalıştırıyoruz. 
        }
    }
}
