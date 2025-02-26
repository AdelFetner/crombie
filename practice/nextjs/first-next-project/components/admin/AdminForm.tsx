"use client"
import React, { useState } from 'react'

export const AdminForm = () => {
    const [name, setName] = useState('')
    const [price, setPrice] = useState('')
    const [description, setDescription] = useState('')


    const handleOnSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault()

        const JSONRequest = JSON.stringify({ name, price, description })

        console.log(JSON.stringify({ name, price, description }))
        const response = await fetch('/api/products', {
            method: 'POST',
            body: JSONRequest,
        })

        if (response.ok) {
            console.log('Product created', await response.json())
        }
    }

    return (
        <form className='flex flex-col gap-4' onSubmit={handleOnSubmit}>
            <label htmlFor='name'>Name</label>
            <input type='text' id='name' name='name' onChange={e => setName(e.target.value)} />

            <label htmlFor='price'>Price</label>
            <input type='number' id='price' name='price' onChange={e => setPrice(e.target.value)} />

            <label htmlFor='description'>Description</label>
            <input type='text' id='description' name='description' onChange={e => setDescription(e.target.value)} />

            <button type='submit'>Submit</button>
        </form>
    )
}
