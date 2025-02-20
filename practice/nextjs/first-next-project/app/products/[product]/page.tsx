import { fakeDB } from '@/app/lib/fakeDB'
import { ProductCard } from '@/components/products/ProductCard'
import React from 'react'

export default function ProductsPage() {
    const Products = fakeDB
    return (
        <main className='flex flex-col items-center justify-center h-screen min-h-full w-full min-w-full'>
            <h1>Products</h1>
            {Products.map((product, index) => (
                <ProductCard key={index} productData={product} />
            ))}
        </main>
    )
}