using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

// playerController�� �÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
public class PlayerController : MonoBehaviour
{
    // ��� �� ����� ����� Ŭ��
    public AudioClip deathClip = default;
    // ���� ��
    public float jumpForce = default;

    // ���� ���� Ƚ��
    private int jumpCount = 0;
    // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isGrounded = false;
    // ��� ����
    private bool isDead = false;

    // ����� ������ٵ� ������Ʈ
    private Rigidbody2D playerRigidbody = default;
    // ����� �ִϸ����� ������Ʈ
    private Animator animator = default;
    // ����� ����� �ҽ� ������Ʈ
    private AudioSource playerAudio = default;
 
    // Start is called before the first frame update
    private void Start()
    {
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�

        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        playerAudio = gameObject.GetComponent<AudioSource>();
        //playerAudio = gameObject.GetComponent<AudioSource>();

        //Func.Assert(playerRigidbody != null || playerRigidbody != default);
        //Func.Assert(animator != null || animator != default);
        //Func.Assert(playerAudio != null || playerAudio != default);
    }

    // Update is called once per frame

    // ����� �Է��� �����ϰ� �����ϴ� ó��
    private void Update()
    {
        if(isDead)
        {
            // ��� �� ó���� �� �̻� �������� �ʰ� ����
            return;
        }

        // ���콺 ������ �������� && �ִ� ���� Ƚ��(2)�� �������� �ʾҴٸ�
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            // ���� Ƚ�� ����
            jumpCount++;
            // ���� ������ �ӵ��� ���������� ����(0,0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            // ������ٵ� �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // ����� �ҽ� ���
            playerAudio.Play();
        }
        else if(Input.GetMouseButtonDown(0) && playerRigidbody.velocity.y > 0)
        {
            // ���콺 ������ ���� ���� && �ӵ��� y���� ������(���� ��� ��)
            // ���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        // �ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded);
    }

    // ��� ó��
    private void Die()
    {
        // �ִϸ޴����� Die Ʈ���� �Ķ���͸� ��
        animator.SetTrigger("Die");

        // ����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.clip = deathClip;
        // ��� ȿ���� ���
        playerAudio.Play();

        // �ӵ��� ����(0,0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        // ��� ���¸� true�� ����
        isDead = true;

        // ���� �Ŵ����� ���ӿ��� ó�� ����
        GameManager.instance.OnPlayerDead();
    }

    // Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "DeadZone" && !isDead)
        {
            // �浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ� Die() ����
            Die();
        }
    }

    // �ٴڿ� ������� �����ϴ� ó�� 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // � �ݶ��̴��� �������, �浹 ǥ���� ������ ���� ������
        if (collision.contacts[0].normal.y > 0.7f)
        {
            // isGrounded��  true�� �����ϰ� ���� ���� Ƚ���� 0���� ����
            isGrounded= true;
            jumpCount = 0;
        }
    }

    // �ٴڿ� ������� �����ϴ� ó��
    private void OnCollisionExit2D(Collision2D collision)
    {
        // � �ݶ��̴����� ������ ��� isGrounded�� false�� ����
        isGrounded= false;
    }
}
