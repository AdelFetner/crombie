"use client"
import {
    Navbar,
    NavbarBrand,
    NavbarContent,
    NavbarItem,
    Avatar,
} from "@heroui/react";
import Link from "next/link";
import { usePathname } from "next/navigation";

export const NavBar = () => {
    const navBarItems = [
        {
            title: "Products",
            href: "/products",
        },
        {
            title: "Categories",
            href: "/categories",
        },
    ];
    const pathName = usePathname();

    return (
        <Navbar position="sticky">
            <NavbarBrand>
                <Link className="font-bold text-inherit" href="/" prefetch={true}>crombiecito</Link>
            </NavbarBrand>

            <NavbarContent className="hidden sm:flex gap-4" justify="center">
                {navBarItems.map((item) => (
                    <NavbarItem key={item.title} isActive={pathName === item.href}>
                        <Link color="foreground
                        " href={item.href} prefetch={true}>
                            {item.title}
                        </Link>
                    </NavbarItem>
                ))}
            </NavbarContent>

            <NavbarContent as="section" justify="end">
                <Link color="foreground" href="/profile" prefetch={true}>
                    <Avatar
                        isBordered
                        as="button"
                        className="transition-transform"
                        color="secondary"
                        name="Jason Hughes"
                        size="sm"
                        src="https://i.pravatar.cc/150" // Random avatar
                    />
                </Link>
            </NavbarContent>
        </Navbar>
    );
}
