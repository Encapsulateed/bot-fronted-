PGDMP  7    -        
        |            front-db    16.3    16.3     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16541    front-db    DATABASE     ~   CREATE DATABASE "front-db" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "front-db";
                postgres    false            �            1259    16542    users    TABLE     �   CREATE TABLE public.users (
    "chatId" bigint NOT NULL,
    uuid character varying(36),
    "JWT" character varying(512),
    command character varying(128),
    email character varying(128),
    password character varying(512)
);
    DROP TABLE public.users;
       public         heap    postgres    false            �          0    16542    users 
   TABLE DATA           P   COPY public.users ("chatId", uuid, "JWT", command, email, password) FROM stdin;
    public          postgres    false    215   �                  2606    16548    users users_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY ("chatId");
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    215            �   �   x��]o�0  ���Pm�}�R�(a��%�����L�_/�^�y�H h4�;�jv�g�v6�Pۄ�DC�[Dho��ױ1�����Ca���������c���F{���6�+(�o���*wUƝ.��z��)G��D���Y�E�2\Y�+��TP���|��a��ta�v�Er�6A9�Wɒ�ha�E4�9x�<d���T����p�EևcY��K�     