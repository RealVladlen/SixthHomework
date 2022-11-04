using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] Rigidbody _playerRigidBody;
    [SerializeField] float _speed;
    [SerializeField] float _maxCharge = 3;
    [SerializeField] float _currenCharge;
    [SerializeField] Transform _spawn;
    [SerializeField] Gun _pistol;
    [SerializeField] ChargeIcon _chargeIcon;

    private bool _isCharged;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _playerRigidBody.AddForce(-_spawn.forward * _speed, ForceMode.VelocityChange);
                _pistol.Shot();
                _isCharged = false;
                _currenCharge = 0;
                _chargeIcon.StartCharge();
            }
        }

        else
        {
            _currenCharge += Time.unscaledDeltaTime;
            _chargeIcon.SetChargeValue(_currenCharge, _maxCharge);

            if (_currenCharge >= _maxCharge)
            {
                _isCharged = true;
                _chargeIcon.StopCharge();
            }
        }
    }
}
