/*
    -------------------------------------
    --            LoE Realm            --
    --        DATABASE STRUCTURE       --
    --                                 --
    --                                 --
    -------------------------------------
    --       Designed by Devwarlt      --
    --           LoESoft Games         --
    -------------------------------------
*/

/* Create database `loe_db` */
create database if not exists `loe_db`;

use `loe_db`;

drop table if exists accounts;

/* Create table `accounts` */
create table accounts (
    id int(12) not null auto_increment,
    accountName varchar(128) not null,
    accountPassword varchar(128) not null,
    rank tinyint(1) not null,
    creationDate datetime not null,
    primary key (id)
)  engine=innodb default charset=utf8;

lock tables accounts write;

unlock tables;

drop table if exists characters;

/* Create table `characters` */
create table characters (
    id int(12) not null auto_increment,
    accountId int(12) not null,
    name varchar(24) not null,
    vocation tinyint(1) not null,
    worldId int(8) not null,
    positionX int(8) not null,
    positionY int(8) not null,
    creationDate datetime not null,
    primary key (id)
)  engine=innodb default charset=utf8;

lock tables characters write;

unlock tables;

drop table if exists depots;

/* Create table `depots` */
create table depots (
    id int(12) not null auto_increment,
    characterId int(12) not null,
    primary key (id)
)  engine=innodb default charset=utf8;

lock tables depots write;

unlock tables;

/* TODO: addition of foreign keys below if needed */