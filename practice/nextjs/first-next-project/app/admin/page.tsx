import { AdminForm } from '@/components/admin/AdminForm'
import React from 'react'

export default async function AdminPage() {
    return (
        <main className='flex flex-col items-center justify-center h-screen min-h-full w-full min-w-full'>
            <h1>admin ultra secret page dont share</h1>
            <AdminForm />
        </main>
    )
}