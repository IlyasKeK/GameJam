using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cannon : MonoBehaviour {

    [SerializeField]
    private bool _Debug = false;

    [SerializeField]
    private GameObject _DebugCannonBall;

    [SerializeField]
    private float _MinFirePower = 20;

    [SerializeField]
    private float _MaxFirePower = 100;

    [SerializeField]
    private float _FirePowerIncrementSpeed = 1;

    [SerializeField]
    private float _CannonRotationOffset = 0;

    [SerializeField]
    private float _CannonBallSpawningDistance = 1;

    [SerializeField]
    private bool _CanShootPositiveX = false;

    private GameObject _CannonBall;
    private float _currentFirePower = 0;
    private bool _canFire = false;

    UnityEvent ShotCannon = new UnityEvent();

    // Use this for initialization
    void Start () {
        if (_Debug && _DebugCannonBall != null)
            _CannonBall = _DebugCannonBall;

        _currentFirePower = _MinFirePower;
	}
	
	// Update is called once per frame
	void Update () {
        if (!_canFire) return;

        RotateToWorldPos(Input.mousePosition);
        IsFireDown();
    }

    private void RotateToWorldPos(Vector3 pPos)
    {
        Vector3 InputPos = pPos;
        
        Vector3 objectpos = Camera.main.WorldToScreenPoint(transform.position);

        if (!AllowedtoFire()) return;

        InputPos.x = InputPos.x - objectpos.x;
        InputPos.y = InputPos.y - objectpos.y;
        
        float angle = Mathf.Atan2(InputPos.y, InputPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + _CannonRotationOffset));
    }

    private bool AllowedtoFire()
    {
        Vector3 objectpos = Camera.main.WorldToScreenPoint(transform.position);

        if (Input.mousePosition.x > objectpos.x && !_CanShootPositiveX) return false;
        if (Input.mousePosition.x < objectpos.x && _CanShootPositiveX) return false;

        return true;
    }

    private void IsFireDown()
    {
        if (Input.GetButton("Fire1"))
        {
            _currentFirePower += _FirePowerIncrementSpeed * Time.deltaTime;
            if (_currentFirePower > _MaxFirePower)
                _currentFirePower = _MaxFirePower;
        }
        else if (_currentFirePower > _MinFirePower)
        {
            if (!AllowedtoFire())
            {
                _currentFirePower = _MinFirePower;
                return;
            }

            Fire();
        }
    }

    private void Fire()
    {
        if (_CannonBall == null)
            return;

        Vector3 forwardVec = transform.right;
        forwardVec = Quaternion.AngleAxis(-_CannonRotationOffset, Vector3.forward) * forwardVec;
        Vector3 worldVec = transform.position;
        Quaternion Rotation = Quaternion.identity;
        Debug.Log("trying to spawn shit");

        GameObject newCannonBall = Instantiate(_CannonBall, worldVec + forwardVec * _CannonBallSpawningDistance, Rotation);
        Rigidbody rgdbody = newCannonBall.GetComponent<Rigidbody>();
        Rigidbody2D rgdbody2d = newCannonBall.GetComponent<Rigidbody2D>();

        if (rgdbody != null)
        {
            rgdbody.velocity = (forwardVec * 20) * _currentFirePower;
        }

        if (rgdbody2d != null)
        {
            rgdbody2d.velocity = (forwardVec * 20) * _currentFirePower;
        }

        ShotCannon.Invoke();
        _currentFirePower = _MinFirePower;
        _canFire = false;
    }

    public void BindShotEvent(UnityAction Call)
    {
        ShotCannon.AddListener(Call);
    }

    public void ResetFire()
    {
        _canFire = true;
    }
}
