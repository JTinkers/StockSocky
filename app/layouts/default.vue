<template>
	<v-app>
		<Nav/>
		<v-main>
			<nuxt/>
		</v-main>
	</v-app>
</template>

<script>
	import Nav from '~/components/layout/Nav'

	export default
	{
		components: { Nav }
	}
</script>
