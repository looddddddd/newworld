﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HeroView : BaseView
{
    public new Text name;
    public Text hp;
    public Text att;
    HeroJson hero;
    [HideInInspector]
    public int preHPChangeValue = 0;

    public void InitData(int heroId)
    {
        hero = HerosModel.GetHeroJsonByHeroId(heroId);
        hero.view = this;
        
        float x = Random.Range(-150,150);
        float y = Random.Range(-300,300);
        RectTransform rtf = GetComponent<RectTransform>();
        rtf.anchoredPosition = new Vector2(x, y);
        rtf.localScale = Vector3.one;
        FreshView();
    }
    void FreshView()
    {
        name.text = hero.name;
        hp.text = hero.hp.ToString();
        att.text = hero.att.ToString();
    }
    public void Fresh(FreshType type)
    {
        switch (type)
        { 
            case FreshType.Hp:
                hp.text = hero.hp.ToString();
                break;
            case FreshType.Att:

                break;
            case FreshType.Die:
                Pooler.PutPoolObj(PoolType.HeroPool.ToString(), gameObject);
                break;
        }
    }
    public void Attacked()
    {
        GameMgr.VSOne(hero);
    }
    protected override void OnBtnClick(string btnName)
    {
        base.OnBtnClick(btnName);
        //查看英雄面板
        GameMgr.VSOne(hero);
    }
}
