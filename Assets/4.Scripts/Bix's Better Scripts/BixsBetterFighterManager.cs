using System.Collections;
using UnityEngine;

public class BixsBetterFighterManager : MonoBehaviour
{
    /*
      This Fighter Manager Script was Revised And Improved by BixTheGameDev since
      Lizband_UCC was unable to make a working one ;)
    */
    private GameObject fighterRoot; // Root position of the fighter

    // Engine Stuff
    private GameObject StatDisplay;
    private GameObject jetEffect;    // The flame effect to enable on ignition

    public float takeOffDistance;   // How far forward should the ship fly on ignition?
    public float stepSpeed;         // forward take off speed
    public bool ignition;           // Is the engine on?
    private bool takeOff;           // Is the fighter trying to take off?
    private bool dock;              // Is the fighter trying to dock?

    private bool tiltingUp;     // Is the joystick in the up position?
    private bool tiltingDown;   // Is the joystick in the down position?
    private bool tiltingLeft;   // Is the joystick in the left position?
    private bool tiltingRight;  // Is the joystick in the right position?



    public float HorizontalTilitLimit = 20;
    public float VerticalTilitLimit = 20;
    public float RotateSpeed = 1f;
    public float ReturnSpeed = 1f;

    public void Start()
    {
        //Gets all of the game objects at the start of the game 
        fighterRoot = transform.parent.gameObject;
        StatDisplay = transform.GetChild(1).GetChild(0).GetChild(1).gameObject;
        jetEffect = transform.GetChild(4).gameObject;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            toggleIgnition();
        }
        if (Input.GetKey(KeyCode.I)) {
            tiltingDown = true;
        }
        else
        {
            tiltingDown = false;
        }
        if (Input.GetKey(KeyCode.K))
        {
            tiltingUp = true;
        }
        else
        {
            tiltingUp = false;
        }
        if (Input.GetKey(KeyCode.J))
        {
            tiltingLeft = true;
        }
        else
        {
            tiltingLeft = false;
        }
        if (Input.GetKey(KeyCode.L))
        {
            tiltingRight = true;
        }
        else
        {
            tiltingRight= false;
        }

        // Flight controls
        if (ignition)
        {
            if (tiltingUp && tiltingLeft)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-HorizontalTilitLimit, 90, -VerticalTilitLimit), RotateSpeed * 10 * Time.deltaTime);
            }
            if (tiltingUp && tiltingRight)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(HorizontalTilitLimit, 90, -VerticalTilitLimit), RotateSpeed * 10 * Time.deltaTime);
            }
            if (tiltingDown && tiltingLeft)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-HorizontalTilitLimit, 90, VerticalTilitLimit), RotateSpeed * 10 * Time.deltaTime);
            }
            if (tiltingDown && tiltingRight)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(HorizontalTilitLimit, 90, VerticalTilitLimit), RotateSpeed * 10 * Time.deltaTime);
            }
            // Tilt Up
            if (tiltingUp)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, 90, -VerticalTilitLimit), RotateSpeed * 10 * Time.deltaTime);
            }
            // Tilt Down
            if (tiltingDown)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.rotation.x, 90, VerticalTilitLimit), RotateSpeed * 10 * Time.deltaTime);
            }
            // Tilt Right
            if (tiltingRight)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(HorizontalTilitLimit, 90, transform.rotation.z), RotateSpeed * 10 * Time.deltaTime);
            }
            // Tilt Left
            if (tiltingLeft)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(-HorizontalTilitLimit, 90, transform.rotation.z), RotateSpeed * 10 * Time.deltaTime);
            }
            if (!tiltingLeft && !tiltingRight && !tiltingUp && !tiltingDown)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 90, 0), ReturnSpeed * 10 * Time.deltaTime);
            }

        }


        // Take Off and Return
        if (takeOff)
        {
            Debug.LogWarning("Take off");
            // move the ship forward a set amount
            GetComponent<Rigidbody>().velocity = fighterRoot.transform.forward * takeOffDistance;
        }

        if (dock)
        {
            Debug.LogWarning("Dock");
            // move the ship backward a set amount
            GetComponent<Rigidbody>().velocity = -fighterRoot.transform.forward * takeOffDistance;
        }
    }


    private IEnumerator TakeOff()
    {
        yield return new WaitForSeconds(3);
        takeOff = false;
        dock = false;
    }


    public void toggleIgnition()
    {
        if (ignition)
        {
            if (!takeOff || !dock)
            {
                dock = true;
                StartCoroutine("TakeOff");
                jetEffect.SetActive(false);
                StatDisplay.SetActive(false);
                ignition = false;
            }
        }

        else if (!ignition)
        {
            if (!takeOff || !dock)
            {
                takeOff = true;
                StartCoroutine("TakeOff");
                jetEffect.SetActive(true);
                StatDisplay.SetActive(true);
                ignition = true;
            }
        }
    }


    public void tiltUpOn()
    {
        tiltingUp = true;
    }
    public void tiltUpOff()
    {
        tiltingUp = false;
    }


    public void tiltDownOn()
    {
        tiltingDown = true;
    }
    public void tiltDownOff()
    {
        tiltingDown = false;
    }


    public void tiltLeftOn()
    {
        tiltingLeft = true;
    }
    public void tiltLeftOff()
    {
        tiltingLeft = false;
    }


    public void tiltRightOn()
    {
        tiltingRight = true;
    }
    public void tiltRightOff()
    {
        tiltingRight = false;
    }
}
