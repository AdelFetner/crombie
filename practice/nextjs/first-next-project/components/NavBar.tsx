import Link from 'next/link'
import React from 'react'

// type Props = {}

export const NavBar = () => {
    return (
        <nav className="sticky top-0 h-16 max-h-16 min-h-16 min-w-full w-full bg-gray-800 text-white flex items-center justify-between px-4">
            <div className="w-2/3">
                <h1>My Blog</h1>
            </div>
            <Link href="/categories">Categories</Link>
            <Link href="/products">Products</Link>
            <Link href="/profile">Profile</Link>
        </nav>
    )
}