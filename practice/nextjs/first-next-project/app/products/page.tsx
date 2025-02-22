import { fakeDB } from '@/app/lib/fakeDB'
import { ProductCard } from '@/components/products/ProductCard'

export default function ProductsPage() {
    return (
        <main className='flex flex-col items-center justify-center h-screen min-h-full w-full min-w-full'>
            <h1>All Products</h1>
            <div className='flex flex-wrap gap-4'>
                {fakeDB.Products.map((product, index) => (
                    <ProductCard productData={product} key={index} />
                ))}
            </div>
        </main>
    )
}