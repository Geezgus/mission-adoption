using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public enum FollowType
    {
        Rigid,
        Lerp,
        Slerp,
    }

    //Populate in Inspector with you players transform
    public Transform    TargetToFollow;

    //The distance the camera will be from the player
    public Vector3      FollowOffset        = new Vector3(0, 0, -10);

    //How quickly the camera moves
    public float        FollowSpeed         = 5f;

    //How the camera will follow
    public FollowType   FollowMethod        = FollowType.Lerp;

    private Transform   _cameraTransform;
    private Vector3     _targetPos;

    private void Start()
    {
        if(TargetToFollow == null)
            Debug.LogError($"{nameof(TargetToFollow)} is null", this);

        _cameraTransform = transform;
    }

    private void LateUpdate()
    {
        switch (FollowMethod)
        {
            case FollowType.Rigid:
                _targetPos = TargetToFollow.position + FollowOffset;
                break;
            case FollowType.Lerp:
                _targetPos = Vector3.Lerp(_cameraTransform.position , TargetToFollow.position + FollowOffset, Time.deltaTime * FollowSpeed);
                break;
            case FollowType.Slerp:
                _targetPos = Vector3.Slerp(_cameraTransform.position, TargetToFollow.position + FollowOffset, Time.deltaTime * FollowSpeed);
                break;
        }

        _cameraTransform.position = _targetPos;
    }
}