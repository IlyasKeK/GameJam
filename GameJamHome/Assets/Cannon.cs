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
    private float MaxFirePower = 100;

    [SerializeField]
    private float FirePowerIncrementSpeed = 1;

    private GameObject _CannonBall;
    private float _currentFirePower = 0;
    private bool _canFire = false;

    UnityEvent Gameloop = new UnityEvent();

    // Use this for initialization
    void Start () {
        if (_Debug && _DebugCannonBall != null)
            _CannonBall = _DebugCannonBall;
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
        InputPos.x = InputPos.x - objectpos.x;
        InputPos.y = InputPos.y - objectpos.y;
        
        float angle = Mathf.Atan2(InputPos.y, InputPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void IsFireDown()
    {
        if (Input.GetButton("Fire1"))
        {
            _currentFirePower += FirePowerIncrementSpeed * Time.deltaTime;
            if (_currentFirePower > MaxFirePower)
                _currentFirePower = MaxFirePower;
        }
        else if (_currentFirePower > 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (_CannonBall == null)
            return;

        Vector3 forwardVec = transform.right;
        Vector3 worldVec = transform.position;
        Quaternion Rotation = Quaternion.identity;
        Debug.Log("trying to spawn shit");

        GameObject newCannonBall = Instantiate(_CannonBall, worldVec + forwardVec * 2, Rotation);
        Rigidbody rgdbody = newCannonBall.GetComponent<Rigidbody>();

        if(rgdbody)
        {
            Debug.Log("setting firepower");
            rgdbody.velocity = (forwardVec * 20) *_currentFirePower;
        }

        Gameloop.Invoke();
        _currentFirePower = 0;
        _canFire = false;
    }

    public void BindShotEvent(UnityAction Call)
    {
        Gameloop.AddListener(Call);
    }

    public void ResetFire()
    {
        _canFire = true;
    }
}
