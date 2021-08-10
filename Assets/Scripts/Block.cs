using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockPoppingVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached refe
    Level level;

    //states

    [SerializeField] int timesHit; //TODO remove, only serialized for debug purposes
    



    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == ("Breakable"))
        {
            level.CountBlocks(); // Kaç adet blok olduğunu söyler.
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == ("Breakable"))
        {
            HandleHit();

        }

    }

    private void HandleHit()  // Eğer TimesHit sayısı birer birer arttığında, maxHit'e ulaşırsa, bloğu yok et. 
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;  // Maxhits sayısını sprite elementinde bulunan sayı ile eşitledik. 
        if (timesHit >= maxHits)
        {
            DestroyBlock();

        }

        else
        {

            ShowNextSprite();
        }

        
    }

    private void ShowNextSprite()
    {
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
        {

            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex]; //GetComponent diğer sprite a geçmemizi sağlar. 
            FindObjectOfType<GameStatus>().AddToScoreOnTouch();  // Kendi eklediğim kod. Kırılmasa bile az puan da olsa geliyor. 
        }
        else
        {
            Debug.LogError("Sprite is missing from array" + gameObject.name);
        }
       
    }

    private void DestroyBlock()   //1. satır skor sayısı ekler. 2. satır ses çalar. 3. sü objeyi yok eder. 4. bi sonraki sahneye geçmemizi sağlar. 
    {
        FindObjectOfType<GameStatus>().AddtoScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        TriggerPopping();
        level.BlockDestroyed();
        
    }

    private void TriggerPopping()
    {

        GameObject sparkles = Instantiate(blockPoppingVFX, transform.position, transform.rotation); //kopyasını yapar
        Destroy(sparkles, 1f); // 2 saniye sonra yok et
    }
}
